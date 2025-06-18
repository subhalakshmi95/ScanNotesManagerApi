using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ScanNotesManager.Properties;
using ScanNotesManager.Repositories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

namespace ScanNotesManager.Controllers
{
    public static class ScanNotesEndpoints
    {
        public static void MapScanNotesEndpoints(this WebApplication app)
        {
            var scanNotesGroup = app.MapGroup("/api/scans");

            scanNotesGroup.MapGet("", GetPatientScanList);
            scanNotesGroup.MapGet("{scanId}/notes", GetScanNotesListByScanId);
            scanNotesGroup.MapPost("{scanId}/notes", InsertScanNote);

        }

        private static async Task<Ok<List<PatientScanData>>> GetPatientScanList(IScanNotesRepository scanNotesRepository)
        {
            var scanList = await scanNotesRepository.GetScanData();
            return TypedResults.Ok(scanList);
        }

        private static async Task<IResult> GetScanNotesListByScanId(int scanId,IScanNotesRepository scanNotesRepository)
        {
            var scanNotesList = await scanNotesRepository.GetScanNotes(scanId);
            return scanNotesList is null ? TypedResults.NotFound(): TypedResults.Ok(scanNotesList);
        }

        private static async Task<IResult> InsertScanNote(int scanId, ScanNotes scanNotes, IScanNotesRepository scanNotesRepository)
        {
            if (!IsValid(scanNotes, out var validationResult))
                return Results.BadRequest(validationResult);

            var scanNotesList = await scanNotesRepository.InsertScanNotes(scanId, scanNotes);
            return Results.Created();
        }

        static bool IsValid<T>(T obj, out ICollection<ValidationResult> results) where T : class
        {
            var validationContext = new ValidationContext(obj);
            results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, results, true);
        }
    }
}
