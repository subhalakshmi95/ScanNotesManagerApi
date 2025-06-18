using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ScanNotesManager.Properties
{
    public class PatientScanData
    {
        public int scanID { get; set; }
        public string scanType {  get; set; }
        public DateTime date { get; set; }
        public string anatomicalRegion {  get; set; }
        public string findings {  get; set; }
        public List<ScanNotes> notes { get; set; }
    }
}
