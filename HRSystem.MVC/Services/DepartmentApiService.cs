using HRSystem.MVC.Models;

public class DepartmentApiService
{
    private readonly HttpClient _httpClient;

    public DepartmentApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Department>> GetAllAsync() =>
        await _httpClient.GetFromJsonAsync<List<Department>>("departments") ?? new List<Department>();

    public async Task<Department?> GetByIdAsync(int id) =>
        await _httpClient.GetFromJsonAsync<Department>($"departments/{id}");

    public async Task<bool> CreateAsync(Department department)
    {
        var response = await _httpClient.PostAsJsonAsync("departments", department);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateAsync(Department department)
    {
        var response = await _httpClient.PutAsJsonAsync($"departments/{department.DepartmentID}", department);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"departments/{id}");
        return response.IsSuccessStatusCode;
    }
}
