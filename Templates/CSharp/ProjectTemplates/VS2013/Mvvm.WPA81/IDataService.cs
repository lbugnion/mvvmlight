using System;

namespace $safeprojectname$.Model
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);
    }
}