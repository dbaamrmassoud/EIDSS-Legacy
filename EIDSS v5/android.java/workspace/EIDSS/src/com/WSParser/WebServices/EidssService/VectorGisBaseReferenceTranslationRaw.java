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

import java.util.Vector;
import com.WSParser.WebServices.EidssService.GisBaseReferenceTranslationRaw;

import org.ksoap2.serialization.KvmSerializable;
import org.ksoap2.serialization.PropertyInfo;
import org.ksoap2.serialization.SoapObject;
import java.util.Hashtable;
@SuppressWarnings("serial")
public class VectorGisBaseReferenceTranslationRaw extends Vector<GisBaseReferenceTranslationRaw> implements KvmSerializable{

    public VectorGisBaseReferenceTranslationRaw(){}
    
    public VectorGisBaseReferenceTranslationRaw(SoapObject soapObject)
    {
        if (soapObject != null){
            int size = soapObject.getPropertyCount();
            for (int i0=0;i0<size;i0++){
                Object obj = soapObject.getProperty(i0);
                if (obj != null && obj.getClass().equals(SoapObject.class)){
                    SoapObject j0 =(SoapObject) soapObject.getProperty(i0);
                    GisBaseReferenceTranslationRaw j1= new GisBaseReferenceTranslationRaw(j0);
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
    public void getPropertyInfo(int arg0, @SuppressWarnings("rawtypes") Hashtable arg1, PropertyInfo arg2) {
        arg2.name = "GisBaseReferenceTranslationRaw";
        arg2.type = GisBaseReferenceTranslationRaw.class;
    }

    @Override
    public void setProperty(int arg0, Object arg1) {
        this.add((GisBaseReferenceTranslationRaw)arg1);
    }

}
