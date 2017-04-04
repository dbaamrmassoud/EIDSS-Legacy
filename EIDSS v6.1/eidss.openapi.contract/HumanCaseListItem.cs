﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eidss.openapi.contract
{
    /// <summary>Short description of Human Case</summary>
    public class HumanCaseListItem 
    {
        /// <summary>
        /// A unique number of the record
        /// </summary>
        public long RecordID { get; set; }

        /// <summary>
        /// A number that is assigned to the individual case and automatically generated by EIDSS. The number appears when the case information is saved first time. 
        /// </summary>
        public string CaseID { get; set; }

        /// <summary>
        /// An unique identification number, determined by each country, used to identify the patient.
        /// </summary>
        public string LocalID { get; set; }

        /// <summary>
        /// Patient's Last name
        /// </summary>
        public string PatientLastName { get; set; }

        /// <summary>
        /// Patient's First name
        /// </summary>
        public string PatientFirstName { get; set; }

/*        /// <summary></summary>
        public string strSecondName { get; set; }

        /// <summary></summary>
        public string strLocationName { get; set; }
*/

        /// <summary>
        /// The date the case information was first entered into EIDSS. The date is auto populated prior to case information being saved. 
        /// </summary>
        public DateTime? DateEntered { get; set; }

        /// <summary>
        /// Patient’s date of birth
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// The date the paper case investigation form was completed
        /// </summary>
        public DateTime? DateOfCompletionOfPaperForm { get; set; }

        /// <summary>
        /// The ultimate diagnosis of a disease or condition confirmed clinically, epidemiologically or via laboratory testing. This is a read-only field, populated by the initial diagnosis or ultimate diagnosis entered in "Changed Diagnosis" field on the Notification tab.<br/>
        /// Reference number: 19000019<br/>
        /// Reference type: Diagnosis
        /// </summary>
        public Diagnosis FinalDiagnosis { get; set; }

        /// <summary>
        /// Classification of the case according to surveillance case definitions based on the initial diagnosis. <br/>
        /// Reference number: 19000011<br/>
        /// Reference type: Case Classification
        /// </summary>
        public Reference InitialCaseClassification { get; set; }

        /// <summary>
        /// Classification of the case according to surveillance case definitions developed based on the final diagnosis, laboratory tests results and epidemiological information. <br/>
        /// Reference number: 19000011<br/>
        /// Reference type: Case Classification
        /// </summary>
        public Reference FinalCaseClassification { get; set; }

        /// <summary>
        /// Status of case information entry into the system. There are two options for this field: In process and Closed. "In process" is the default option. Status should be changed to "Closed", after laboratory and epidemiological investigation is completed and final diagnosis made, thus making all the data fields "read-only".<br/>
        /// Reference number: 19000111<br/>
        /// Reference type: Case Status
        /// </summary>
        public Reference CaseStatus { get; set; }

        /// <summary>
        /// Patient’s current age, calculated automatically upon entry of DOB (calculated from Date of Symptom Onset, if it is blank, than - Notification Date, if it is blank, than – Date Entered). If DOB is unknown, user can enter the age of the patient manually to the field.
        /// </summary>
        public int? Age { get; set; }

        /// <summary>
        /// Patient’s age type (days, months, years), populated automatically when DOB is entered.<br/>
        /// Reference type: Human Age Type<br/>
        /// Reference number: 19000042
        /// </summary>
        public Reference AgeType { get; set; }

        /// <summary>
        /// Country<br/>
        /// Reference type: Country<br/>
        /// Reference number: 19000001
        /// </summary>
        public GisReference CurrentResidenceCountry { get; set; }

        /// <summary>
        /// Region<br/>
        /// Reference type: Region<br/>
        /// Reference number: 19000002
        /// </summary>
        public GisReference CurrentResidenceRegion { get; set; }

        /// <summary>
        /// Rayon<br/>
        /// Reference type: Rayon<br/>
        /// Reference number: 19000003
        /// </summary>
        public GisReference CurrentResidenceRayon { get; set; }

        /// <summary>
        /// Settlement<br/>
        /// Reference type: Settlement<br/>
        /// Reference number: 19000004
        /// </summary>
        public GisReference CurrentResidenceSettlement { get; set; }

    }
}