using System.Net.Http.Json;
using ToDoList.Core.DTOs;

namespace ToDoList.Web.Services
{
    public class UserApiService
    {
        private readonly HttpClient _httpClient;
        public UserApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<UserWithUserRoleDto>> GetUserWithUserRoleAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<UserWithUserRoleDto>>>("user/GetUserWithUserRole");
            return response.Data;
        }
        public async Task<List<UserDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<UserDto>>>("user");
            return response.Data;
        }
        public async Task<UserDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<UserDto>>($"user/{id}");
            return response.Data;
        }
        public async Task<UserDto> SaveAsync(UserDto userDto)
        {
            var response = await _httpClient.PostAsJsonAsync("user", userDto);
            if (!response.IsSuccessStatusCode) return null;

            var responseBody=await response.Content.ReadFromJsonAsync<CustomResponseDto<UserDto>>();

            return responseBody.Data; 
        }

        public async Task<bool> UpdateAsync(UserDto userDto)
        {
         var response=  await _httpClient.PutAsJsonAsync("user", userDto);
    
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"user/{id}");

            return response.IsSuccessStatusCode;
        }
        
    }
}
