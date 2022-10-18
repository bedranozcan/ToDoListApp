using ToDoList.Core.DTOs;

namespace ToDoList.Web.Services
{
    public class NoteApiService
    {
        private readonly HttpClient _httpClient;

        public NoteApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<NoteWithUserDto>> GetAllNoteWithUsers()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<NoteWithUserDto>>>
                ("note/GetNoteWithUser");

            return response.Data;
        }
        public async Task<List<NoteDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<NoteDto>>>("note");
            return response.Data;
        }

        public async Task<NoteDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<NoteDto>>($"note/{id}");
            return response.Data;
        }

        public async Task<NoteDto> SaveAsync(NoteDto noteDto)
        {
            var response = await _httpClient.PostAsJsonAsync("note", noteDto);
            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<NoteDto>>();

            return responseBody.Data;
        }

        public async Task<bool> UpdateAsync(NoteDto noteDto)
        {
            var response = await _httpClient.PutAsJsonAsync("note", noteDto);

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"note/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
