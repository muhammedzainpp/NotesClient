﻿using Notes.Web.Dtos.Notes.GetNotesQuery;
using Notes.Web.Dtos.Notes.SaveNoteCommand;
using Notes.Web.Services.Interfaces;

namespace Notes.Web.Services;

public class NoteService : INoteService
{
    private readonly IApiService _apiService;

    public NoteService(IApiService apiService) => _apiService = apiService;

    public async Task<int> SaveNoteAsync(SaveNoteCommand request)
    {
        var url = "notes";
        var response = await _apiService.PostAsync<SaveNoteCommand, int>(request, url);
        return response;
    }

    public async Task<IEnumerable<GetNotesDto>?> GetNotesAsync()
    {
        var url = "notes";
        var response = await _apiService.GetAsync<IEnumerable<GetNotesDto>>(url);
        return response;
    }
}