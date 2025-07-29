using HRSystem.MVC.Models;

public class DeductionComponentApiService
{
    private readonly HttpClient _httpClient;

    public DeductionComponentApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<DeductionComponent>> GetAllAsync() =>
        await _httpClient.GetFromJsonAsync<List<DeductionComponent>>("deductioncomponent") ?? new List<DeductionComponent>();

    public async Task<DeductionComponent?> GetByIdAsync(int id) =>
        await _httpClient.GetFromJsonAsync<DeductionComponent>($"deductioncomponent/{id}");

    public async Task<bool> CreateAsync(DeductionComponent deductionComponent)
    {
        var response = await _httpClient.PostAsJsonAsync("deductioncomponent", deductionComponent);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateAsync(DeductionComponent deductionComponent)
    {
        var response = await _httpClient.PutAsJsonAsync($"deductioncomponent/{deductionComponent.DeductionID}", deductionComponent);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"deductioncomponent/{id}");
        return response.IsSuccessStatusCode;
    }
}
