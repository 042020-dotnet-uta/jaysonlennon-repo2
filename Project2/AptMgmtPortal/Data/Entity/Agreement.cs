using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AptMgmtPortal.Entity
{
    public class Agreement
    {
        public int AgreementId { get; set; }
        /// <summary>
        /// title of the agreement ex: lease agreement, utility agreement 
        /// </summary>
        public string AgreementTitle { get; set; }
        public string AgreementText { get; set; }
    }
}
