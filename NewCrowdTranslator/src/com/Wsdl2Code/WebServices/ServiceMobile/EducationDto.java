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

import org.ksoap2.serialization.KvmSerializable;
import org.ksoap2.serialization.PropertyInfo;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapPrimitive;

public class EducationDto implements KvmSerializable, Serializable {
    
    public String educationDescription;
    public String educationId;
    
    public EducationDto(){}
    
    public EducationDto(SoapObject soapObject)
    {
        if (soapObject == null)
            return;
        if (soapObject.hasProperty("EducationDescription"))
        {
            Object obj = soapObject.getProperty("EducationDescription");
            if (obj != null && obj.getClass().equals(SoapPrimitive.class)){
                SoapPrimitive j =(SoapPrimitive) obj;
                educationDescription = j.toString();
            }else if (obj!= null && obj instanceof String){
                educationDescription = (String) obj;
            }
        }
        if (soapObject.hasProperty("EducationId"))
        {
            Object obj = soapObject.getProperty("EducationId");
            if (obj != null && obj.getClass().equals(SoapPrimitive.class)){
                SoapPrimitive j =(SoapPrimitive) obj;
                educationId = j.toString();
            }else if (obj!= null && obj instanceof String){
                educationId = (String) obj;
            }
        }
    }
    @Override
    public Object getProperty(int arg0) {
        switch(arg0){
            case 0:
                return educationDescription;
            case 1:
                return educationId;
        }
        return null;
    }
    
    @Override
    public int getPropertyCount() {
        return 2;
    }
    
    @Override
    public void getPropertyInfo(int index, @SuppressWarnings("rawtypes") Hashtable arg1, PropertyInfo info) {
        switch(index){
            case 0:
                info.type = PropertyInfo.STRING_CLASS;
                info.name = "EducationDescription";
                break;
            case 1:
                info.type = PropertyInfo.STRING_CLASS;
                info.name = "EducationId";
                break;
        }
    }
    

    
    
    @Override
    public void setProperty(int arg0, Object arg1) {
    }
    
}
