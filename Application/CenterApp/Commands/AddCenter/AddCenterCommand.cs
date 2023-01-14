using Application.Common.Mediatr;
using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CenterApp{
    public class AddCenterCommand : IRequestWrapper<bool>
    {
        public int CenterId { get; set; }
        public string CenterName { get; set; }
        public string CenterNameInEnglish { get; set; }
        public string OverView { get; set; }
        public bool IsSchoolInstitue { get; set; }
        public bool IsIinitalized { get; set; }
        public DateTime StartDate { get; set; }
        public string LogoPhotoPath { get; set; }
        public string LoginPagePhotoPath { get; set; }

        public string OwnerId { get; set; }
    }
}
