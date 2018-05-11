using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public interface ISettingsService
    {
        AppSettings GetSettings();
        bool Save();
        void AddSampleCameras();
    }
}
