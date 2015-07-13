using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMNewJobWebsite.Models;
using UMNewJobWebsite.Service.Interface;
using UMNewJobWebsite.Exceptions.Service;

namespace UMNewJobWebsite.Business
{
    public class EmployerManager : BusinessManager
    {

        public List<Employer> selectAllEmployer()
        {
            try
            {
                IEmployerSvc svc = (IEmployerSvc)this.getService(typeof(IEmployerSvc).Name);
                return svc.selectAllEmployer();
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public Employer selectEmployerById(Employer obj)
        {
            try
            {
                IEmployerSvc svc = (IEmployerSvc)this.getService(typeof(IEmployerSvc).Name);
                return svc.selectEmployerById(obj);
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public Boolean insertEmployer(Employer obj)
        {
            try
            {
                IEmployerSvc svc = (IEmployerSvc)this.getService(typeof(IEmployerSvc).Name);
                return svc.insertEmployer(obj);


            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        public Boolean updateEmployer(Employer obj)
        {
            try
            {
                IEmployerSvc svc = (IEmployerSvc)this.getService(typeof(IEmployerSvc).Name);
                return svc.updateEmployer(obj);

            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        public Boolean deleteEmployer(Employer obj)
        {
            try
            {
                IEmployerSvc svc = (IEmployerSvc)this.getService(typeof(IEmployerSvc).Name);
                return svc.deleteEmployer(obj);
            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }
    }
}
