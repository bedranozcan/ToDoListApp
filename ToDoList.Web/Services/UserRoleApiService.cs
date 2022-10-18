using ToDoList.Core.DTOs;

namespace ToDoList.Web.Services
{
    public class UserRoleApiService
    {
        private  readonly HttpClient _httpClient;
        public UserRoleApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<UserRoleDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<UserRoleDto>>>("userrole");
            return response.Data;
        }

        public async Task<UserRoleDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<UserRoleDto>>($"userrole/{id}");
            return response.Data;
        }

        public async Task<UserRoleDto> SaveAsync(UserRoleDto userRoleDto)
        {
            var response = await _httpClient.PostAsJsonAsync("userrole", userRoleDto);
            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<UserRoleDto>>();

            return responseBody.Data;
        }

        public async Task<bool> UpdateAsync(UserRoleDto userRoleDto)
        {
            var response = await _httpClient.PutAsJsonAsync("userrole", userRoleDto);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"userrole/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
