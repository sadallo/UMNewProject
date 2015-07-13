using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMNewJobWebsite.Models;
using UMNewJobWebsite.Service.Interface;
using UMNewJobWebsite.Exceptions.Service;

namespace UMNewJobWebsite.Business
{
    public class CompensationManager : BusinessManager
    {

        public List<Compensation> selectAllCompensation()
        {
            try
            {
                ICompensationSvc svc = (ICompensationSvc)this.getService(typeof(ICompensationSvc).Name);
                return svc.selectAllCompensation();
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public Compensation selectCompensationById(Compensation obj)
        {
            try
            {
                ICompensationSvc svc = (ICompensationSvc)this.getService(typeof(ICompensationSvc).Name);
                return svc.selectCompensationById(obj);
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public Boolean insertCompensation(Compensation obj)
        {
            try
            {
                ICompensationSvc svc = (ICompensationSvc)this.getService(typeof(ICompensationSvc).Name);
                return svc.insertCompensation(obj);


            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        public Boolean updateCompensation(Compensation obj)
        {
            try
            {
                ICompensationSvc svc = (ICompensationSvc)this.getService(typeof(ICompensationSvc).Name);
                return svc.updateCompensation(obj);

            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        public Boolean deleteCompensation(Compensation obj)
        {
            try
            {
                ICompensationSvc svc = (ICompensationSvc)this.getService(typeof(ICompensationSvc).Name);
                return svc.deleteCompensation(obj);
            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }
    }
}
