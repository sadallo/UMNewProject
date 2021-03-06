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

public class IncomeDto implements KvmSerializable, Serializable {
    
    public String incomeDescription;
    public String incomeId;
    
    public IncomeDto(){}
    
    public IncomeDto(SoapObject soapObject)
    {
        if (soapObject == null)
            return;
        if (soapObject.hasProperty("IncomeDescription"))
        {
            Object obj = soapObject.getProperty("IncomeDescription");
            if (obj != null && obj.getClass().equals(SoapPrimitive.class)){
                SoapPrimitive j =(SoapPrimitive) obj;
                incomeDescription = j.toString();
            }else if (obj!= null && obj instanceof String){
                incomeDescription = (String) obj;
            }
        }
        if (soapObject.hasProperty("IncomeId"))
        {
            Object obj = soapObject.getProperty("IncomeId");
            if (obj != null && obj.getClass().equals(SoapPrimitive.class)){
                SoapPrimitive j =(SoapPrimitive) obj;
                incomeId = j.toString();
            }else if (obj!= null && obj instanceof String){
                incomeId = (String) obj;
            }
        }
    }
    @Override
    public Object getProperty(int arg0) {
        switch(arg0){
            case 0:
                return incomeDescription;
            case 1:
                return incomeId;
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
                info.name = "IncomeDescription";
                break;
            case 1:
                info.type = PropertyInfo.STRING_CLASS;
                info.name = "IncomeId";
                break;
        }
    }
    

    
    
    @Override
    public void setProperty(int arg0, Object arg1) {
    }
    
}
