using Microsoft.AspNetCore.Mvc;
using ScanNotesManager.Properties;

namespace ScanNotesManager.Repositories
{
    public interface IScanNotesRepository
    {
        //public async Task<IEnumerable<PatientScanData>> getPatientScanList { get; }
        //public async Task<PatientScanData> getPatientScanDetails { get; }
        //public async Task<ScanNotes> insertScanNotes { get; }


        Task<List<PatientScanData>> GetScanData();

        Task<PatientScanData> GetScanNotes(int scanId);
        Task<List<ScanNotes>> InsertScanNotes(int scanId, ScanNotes scanNotes);
    }
}
