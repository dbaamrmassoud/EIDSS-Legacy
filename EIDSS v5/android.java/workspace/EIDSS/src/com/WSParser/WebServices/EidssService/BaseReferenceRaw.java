//------------------------------------------------------------------------------
// <wsdl2code-generated>
//    This code was generated by http://www.wsdl2code.com version Beta 1.2
//
//    Please dont change this code, regeneration will override your changes
//</wsdl2code-generated>
//
//------------------------------------------------------------------------------
//
//This source code was auto-generated by Wsdl2Code Beta Version
//
package com.WSParser.WebServices.EidssService;

import org.ksoap2.serialization.KvmSerializable;
import org.ksoap2.serialization.PropertyInfo;
import java.util.Hashtable;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapPrimitive;

import android.content.ContentValues;

public class BaseReferenceRaw implements KvmSerializable {

    public String NAMESPACE =" http://bv.com/eidss";
    public long idfsBaseReference;
    public long idfsReferenceType;
    public int intHACode;
    public String strDefault;

    public ContentValues ContentValues()
    {
    	ContentValues ret = new ContentValues();
        ret.put("idfsBaseReference", idfsBaseReference);
        ret.put("idfsReferenceType", idfsReferenceType);
        ret.put("intHACode", intHACode);
        ret.put("strDefault", strDefault);
        return ret;
    }
    
    public BaseReferenceRaw(){}
    
    public BaseReferenceRaw(SoapObject soapObject){
    
        if (soapObject.hasProperty("idfsBaseReference"))
        {
            Object obj = soapObject.getProperty("idfsBaseReference");
            if (obj != null && obj.getClass().equals(SoapPrimitive.class)){
                SoapPrimitive j25 =(SoapPrimitive) soapObject.getProperty("idfsBaseReference");
                idfsBaseReference = Long.parseLong(j25.toString());
            }
        }
        if (soapObject.hasProperty("idfsReferenceType"))
        {
            Object obj = soapObject.getProperty("idfsReferenceType");
            if (obj != null && obj.getClass().equals(SoapPrimitive.class)){
                SoapPrimitive j26 =(SoapPrimitive) soapObject.getProperty("idfsReferenceType");
                idfsReferenceType = Long.parseLong(j26.toString());
            }
        }
        if (soapObject.hasProperty("intHACode"))
        {
            Object obj = soapObject.getProperty("intHACode");
            if (obj != null && obj.getClass().equals(SoapPrimitive.class)){
                SoapPrimitive j27 =(SoapPrimitive) soapObject.getProperty("intHACode");
                intHACode = Integer.parseInt(j27.toString());
            }
        }
        if (soapObject.hasProperty("strDefault"))
        {
            Object obj = soapObject.getProperty("strDefault");
            if (obj != null && obj.getClass().equals(SoapPrimitive.class)){
                SoapPrimitive j28 =(SoapPrimitive) soapObject.getProperty("strDefault");
                strDefault = j28.toString();
            }
        }
    }
    @Override
    public Object getProperty(int arg0) {
    switch(arg0){
        case 0:
            return idfsBaseReference;
        case 1:
            return idfsReferenceType;
        case 2:
            return intHACode;
        case 3:
            return strDefault;
    }
    return null;
    }
    @Override
    public int getPropertyCount() {
        return 4;
    }
    @Override
    public void getPropertyInfo(int index, @SuppressWarnings("rawtypes") Hashtable arg1, PropertyInfo info) {
    switch(index){
        case 0:
            info.type = Long.class;
            info.name = "idfsBaseReference";
            break;
        case 1:
            info.type = Long.class;
            info.name = "idfsReferenceType";
            break;
        case 2:
            info.type = PropertyInfo.INTEGER_CLASS;
            info.name = "intHACode";
            break;
        case 3:
            info.type = PropertyInfo.STRING_CLASS;
            info.name = "strDefault";
            break;
    }
    }
    @Override
    public void setProperty(int index, Object value) {
    switch(index){
        case 0:
        idfsBaseReference = Long.parseLong(value.toString()) ;
        break;
        case 1:
        idfsReferenceType = Long.parseLong(value.toString()) ;
        break;
        case 2:
        intHACode = Integer.parseInt(value.toString()) ;
        break;
        case 3:
        strDefault = value.toString() ;
        break;
}
}
}
