using HRSystem.MVC.Models;

public class EmployeeAssignmentApiService
{
    private readonly HttpClient _httpClient;

    public EmployeeAssignmentApiService(HttpClient client)
    {
        client.Timeout = TimeSpan.FromMinutes(5); // Increase timeout
        _httpClient = client;
    }


    public async Task<List<EmployeeDepartment>> GetAllAsync() =>
        await _httpClient.GetFromJsonAsync<List<EmployeeDepartment>>("EmployeeAssignment") ?? new List<EmployeeDepartment>();

    public async Task<EmployeeDepartment?> GetByIdAsync(int id) =>
        await _httpClient.GetFromJsonAsync<EmployeeDepartment>($"EmployeeAssignment/{id}");

    public async Task<bool> CreateAsync(EmployeeDepartment assignment)
    {
        var response = await _httpClient.PostAsJsonAsync("EmployeeAssignment", assignment);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateAsync(EmployeeDepartment assignment)
    {
        var response = await _httpClient.PutAsJsonAsync($"EmployeeAssignment/{assignment.EmpDeptID}", assignment);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"Employeeassignment/{id}");
        return response.IsSuccessStatusCode;
    }
}