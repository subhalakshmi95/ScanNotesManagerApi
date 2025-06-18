using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ScanNotesManager.Properties;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ScanNotesManager.Repositories
{
    public class ScanNotesRepository : IScanNotesRepository
    {
        private readonly List<PatientScanData> _patientScansList;

        public ScanNotesRepository()
        {
            _patientScansList = new List<PatientScanData>();

            using (StreamReader r = new StreamReader("PatientScanData.json"))
            {
                string json = r.ReadToEnd();
                _patientScansList = JsonConvert.DeserializeObject<List<PatientScanData>>(json);
            }

        }

        public async Task<List<PatientScanData>> GetScanData()
        {
            return await Task.FromResult(this._patientScansList);
        }

        public async Task<PatientScanData> GetScanNotes(int scanId)
        {
            PatientScanData scanNotes=  this._patientScansList.FirstOrDefault(x=>x.scanID==scanId);
            return await Task.FromResult(scanNotes);
        }

        public async Task<List<ScanNotes>> InsertScanNotes(int scanId, ScanNotes newScanNote)
        {
            List<ScanNotes> scanNotes = this._patientScansList.FirstOrDefault(x => x.scanID == scanId)?.notes;
            scanNotes.Add(newScanNote);
            var convertedJson = JsonConvert.SerializeObject(this._patientScansList, Formatting.Indented);
            File.WriteAllText("PatientScanData.json", convertedJson);
            return await Task.FromResult(scanNotes);
        }

    }
}
