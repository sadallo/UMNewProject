package com.Wsdl2Code.WebServices.ServiceMobile;

//------------------------------------------------------------------------------
// <wsdl2code-generated>
//    This code was generated by http://www.wsdl2code.com version  2.6
//
// Date Of Creation: 7/29/2015 10:05:22 PM
//    Please dont change this code, regeneration will override your changes
//</wsdl2code-generated>
//
//------------------------------------------------------------------------------
//
//This source code was auto-generated by Wsdl2Code  Version
//
import java.io.Serializable;
import java.util.Hashtable;
import java.util.Vector;

import org.ksoap2.serialization.KvmSerializable;
import org.ksoap2.serialization.PropertyInfo;
import org.ksoap2.serialization.SoapObject;

public class VectorRecommendedJobDto extends Vector<RecommendedJobDto> implements KvmSerializable, Serializable {
    
    
    public VectorRecommendedJobDto(){}
    
    public VectorRecommendedJobDto(SoapObject soapObject)
    {
        if (soapObject == null)
            return;
        if (soapObject != null){
            int size = soapObject.getPropertyCount();
            for (int i0=0;i0<size;i0++){
                Object obj = soapObject.getProperty(i0);
                if (obj!=null && obj.getClass().equals(SoapObject.class)){
                    SoapObject j0 =(SoapObject) soapObject.getProperty(i0);
                    RecommendedJobDto j1= new RecommendedJobDto(j0);
                    add(j1);
                }
            }
        }
    }
    @Override
    public Object getProperty(int arg0) {
        return this.get(arg0);
    }
    
    @Override
    public int getPropertyCount() {
        return this.size();
    }
    
    @Override
    public void getPropertyInfo(int index, @SuppressWarnings("rawtypes") Hashtable arg1, PropertyInfo info) {
        info.name = "RecommendedJobDto";
        info.type = RecommendedJobDto.class;
    }
    

    
    @Override
    public void setProperty(int arg0, Object arg1) {
    }
    
}
