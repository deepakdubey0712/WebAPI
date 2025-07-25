using HRSystem.MVC.Models;

public class EmployeeApiService
{
    private readonly HttpClient _httpClient;

    public EmployeeApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Employee>> GetAllAsync() =>
        await _httpClient.GetFromJsonAsync<List<Employee>>("employees") ?? new List<Employee>();

    public async Task<Employee?> GetByIdAsync(int id) =>
        await _httpClient.GetFromJsonAsync<Employee>($"employees/{id}");

    public async Task<bool> CreateAsync(Employee employee)
    {
        var response = await _httpClient.PostAsJsonAsync("employees", employee);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateAsync(Employee employee)
    {
        var response = await _httpClient.PutAsJsonAsync($"employees/{employee.EmployeeID}", employee);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"employees/{id}");
        return response.IsSuccessStatusCode;
    }
}
