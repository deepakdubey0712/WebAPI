using HRSystem.MVC.Models;


public class EmployeeGradeApiService
{
    private readonly HttpClient _httpClient;

    public EmployeeGradeApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<EmployeeGrade>> GetAllAsync() =>
        await _httpClient.GetFromJsonAsync<List<EmployeeGrade>>("GradeAssignment") ?? new();

    public async Task<EmployeeGrade?> GetByIdAsync(int id) =>
        await _httpClient.GetFromJsonAsync<EmployeeGrade>($"GradeAssignment/{id}");

    public async Task<bool> CreateAsync(EmployeeGrade model)
    {
        var response = await _httpClient.PostAsJsonAsync("GradeAssignment", model);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateAsync(EmployeeGrade model)
    {
        var response = await _httpClient.PutAsJsonAsync($"GradeAssignment/{model.EmployeeGradeID}", model);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"GradeAssignment/{id}");
        return response.IsSuccessStatusCode;
    }
}
