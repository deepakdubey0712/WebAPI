CREATE OR REPLACE PROCEDURE GeneratePayslip(
    IN p_EmployeeID INT,
    IN p_Month INT,
    IN p_Year INT
)
LANGUAGE plpgsql
AS $$
DECLARE
    v_TotalEarnings DECIMAL(10,2) := 0;
    v_TotalDeductions DECIMAL(10,2) := 0;
    v_NetPay DECIMAL(10,2);
    v_PayslipID INT;
    v_ComponentID INT;
    v_Amount DECIMAL(10,2);
    v_IsTaxable BOOLEAN;
    v_Today DATE := CURRENT_DATE;
BEGIN
    -- Insert into Payslips table
    INSERT INTO Payslips (EmployeeID, Month, Year, PayslipDate)
    VALUES (p_EmployeeID, p_Month, p_Year, v_Today)
    RETURNING PayslipID INTO v_PayslipID;

    -- Loop through salary components
    FOR v_ComponentID, v_Amount, v_IsTaxable IN
        SELECT es.ComponentID, es.Amount, sc.IsTaxable
        FROM EmployeeSalaries es
        JOIN SalaryComponents sc ON es.ComponentID = sc.ComponentID
        WHERE es.EmployeeID = p_EmployeeID
    LOOP
        -- Insert into PayslipComponents
        INSERT INTO PayslipComponents (PayslipID, ComponentID, Amount)
        VALUES (v_PayslipID, v_ComponentID, v_Amount);

        -- Calculate totals
        IF v_IsTaxable THEN
            v_TotalDeductions := v_TotalDeductions + (v_Amount * 0.1); -- Example: 10% tax
        END IF;
        v_TotalEarnings := v_TotalEarnings + v_Amount;
    END LOOP;

    -- Calculate Net Pay
    v_NetPay := v_TotalEarnings - v_TotalDeductions;

    -- Update Payslip with totals
    UPDATE Payslips
    SET TotalEarnings = v_TotalEarnings,
        TotalDeductions = v_TotalDeductions,
        NetPay = v_NetPay
    WHERE PayslipID = v_PayslipID;
END;
$$;
