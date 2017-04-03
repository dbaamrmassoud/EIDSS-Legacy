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
import com.WSParser.WebServices.EidssService.BaseReferenceItem;

public class AddressInfo implements KvmSerializable {

    public String NAMESPACE =" http://bv.com/eidss";
    public BaseReferenceItem country;
    public BaseReferenceItem region;
    public BaseReferenceItem rayon;
    public BaseReferenceItem settlement;
    public String building;
    public String house;
    public String apartment;
    public String street;
    public String zipCode;
    public String homePhone;
    
    public AddressInfo(){}
    
    public AddressInfo(SoapObject soapObject){
    
        if (soapObject.hasProperty("Country"))
        {
            SoapObject j59 = (SoapObject)soapObject.getProperty("Country");
            country =  new BaseReferenceItem (j59);
            
        }
        if (soapObject.hasProperty("Region"))
        {
            SoapObject j60 = (SoapObject)soapObject.getProperty("Region");
            region =  new BaseReferenceItem (j60);
            
        }
        if (soapObject.hasProperty("Rayon"))
        {
            SoapObject j61 = (SoapObject)soapObject.getProperty("Rayon");
            rayon =  new BaseReferenceItem (j61);
            
        }
        if (soapObject.hasProperty("Settlement"))
        {
            SoapObject j62 = (SoapObject)soapObject.getProperty("Settlement");
            settlement =  new BaseReferenceItem (j62);
            
        }
        if (soapObject.hasProperty("Building"))
        {
            Object obj = soapObject.getProperty("Building");
            if (obj != null && obj.getClass().equals(SoapPrimitive.class)){
                SoapPrimitive j63 =(SoapPrimitive) soapObject.getProperty("Building");
                building = j63.toString();
            }
        }
        if (soapObject.hasProperty("House"))
        {
            Object obj = soapObject.getProperty("House");
            if (obj != null && obj.getClass().equals(SoapPrimitive.class)){
                SoapPrimitive j64 =(SoapPrimitive) soapObject.getProperty("House");
                house = j64.toString();
            }
        }
        if (soapObject.hasProperty("Apartment"))
        {
            Object obj = soapObject.getProperty("Apartment");
            if (obj != null && obj.getClass().equals(SoapPrimitive.class)){
                SoapPrimitive j65 =(SoapPrimitive) soapObject.getProperty("Apartment");
                apartment = j65.toString();
            }
        }
        if (soapObject.hasProperty("Street"))
        {
            Object obj = soapObject.getProperty("Street");
            if (obj != null && obj.getClass().equals(SoapPrimitive.class)){
                SoapPrimitive j66 =(SoapPrimitive) soapObject.getProperty("Street");
                street = j66.toString();
            }
        }
        if (soapObject.hasProperty("ZipCode"))
        {
            Object obj = soapObject.getProperty("ZipCode");
            if (obj != null && obj.getClass().equals(SoapPrimitive.class)){
                SoapPrimitive j67 =(SoapPrimitive) soapObject.getProperty("ZipCode");
                zipCode = j67.toString();
            }
        }
        if (soapObject.hasProperty("HomePhone"))
        {
            Object obj = soapObject.getProperty("HomePhone");
            if (obj != null && obj.getClass().equals(SoapPrimitive.class)){
                SoapPrimitive j68 =(SoapPrimitive) soapObject.getProperty("HomePhone");
                homePhone = j68.toString();
            }
        }
    }
    @Override
    public Object getProperty(int arg0) {
    switch(arg0){
        case 0:
            return country;
        case 1:
            return region;
        case 2:
            return rayon;
        case 3:
            return settlement;
        case 4:
            return building;
        case 5:
            return house;
        case 6:
            return apartment;
        case 7:
            return street;
        case 8:
            return zipCode;
        case 9:
            return homePhone;
    }
    return null;
    }
    @Override
    public int getPropertyCount() {
        return 10;
    }
    @Override
    public void getPropertyInfo(int index, @SuppressWarnings("rawtypes") Hashtable arg1, PropertyInfo info) {
    switch(index){
        case 0:
            info.type = BaseReferenceItem.class;
            info.name = "Country";
            break;
        case 1:
            info.type = BaseReferenceItem.class;
            info.name = "Region";
            break;
        case 2:
            info.type = BaseReferenceItem.class;
            info.name = "Rayon";
            break;
        case 3:
            info.type = BaseReferenceItem.class;
            info.name = "Settlement";
            break;
        case 4:
            info.type = PropertyInfo.STRING_CLASS;
            info.name = "Building";
            break;
        case 5:
            info.type = PropertyInfo.STRING_CLASS;
            info.name = "House";
            break;
        case 6:
            info.type = PropertyInfo.STRING_CLASS;
            info.name = "Apartment";
            break;
        case 7:
            info.type = PropertyInfo.STRING_CLASS;
            info.name = "Street";
            break;
        case 8:
            info.type = PropertyInfo.STRING_CLASS;
            info.name = "ZipCode";
            break;
        case 9:
            info.type = PropertyInfo.STRING_CLASS;
            info.name = "HomePhone";
            break;
    }
    }
    @Override
    public void setProperty(int index, Object value) {
    switch(index){
        case 0:
        country = (BaseReferenceItem)value;
        break;
        case 1:
        region = (BaseReferenceItem)value;
        break;
        case 2:
        rayon = (BaseReferenceItem)value;
        break;
        case 3:
        settlement = (BaseReferenceItem)value;
        break;
        case 4:
        building = value.toString() ;
        break;
        case 5:
        house = value.toString() ;
        break;
        case 6:
        apartment = value.toString() ;
        break;
        case 7:
        street = value.toString() ;
        break;
        case 8:
        zipCode = value.toString() ;
        break;
        case 9:
        homePhone = value.toString() ;
        break;
}
}
}
