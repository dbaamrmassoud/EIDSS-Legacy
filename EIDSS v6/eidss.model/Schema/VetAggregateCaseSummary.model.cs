﻿#pragma warning disable 0472
using System;
using System.Text;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Xml.Serialization;
using BLToolkit.Aspects;
using BLToolkit.DataAccess;
using BLToolkit.EditableObjects;
using BLToolkit.Data;
using BLToolkit.Data.DataProvider;
using BLToolkit.Mapping;
using BLToolkit.Reflection;
using bv.common.Configuration;
using bv.common.Enums;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model;
using bv.model.Helpers;
using bv.model.Model.Extenders;
using bv.model.Model.Core;
using bv.model.Model.Handlers;
using bv.model.Model.Validators;
using eidss.model.Core;
using eidss.model.Enums;
		

namespace eidss.model.Schema
{
        
        
    [XmlType(AnonymousType = true)]
    public abstract partial class VetAggregateCaseSummary : 
        EditableObject<VetAggregateCaseSummary>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfAggrCase), NonUpdatable, PrimaryKey]
        public abstract Int64 idfAggrCase { get; set; }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<VetAggregateCaseSummary, object> _get_func;
            internal Action<VetAggregateCaseSummary, string> _set_func;
            internal Action<VetAggregateCaseSummary, VetAggregateCaseSummary, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfAggrCase = "idfAggrCase";
        internal const string _str_idfsPeriodType = "idfsPeriodType";
        internal const string _str_idfsAreaType = "idfsAreaType";
        internal const string _str_StatisticPeriodType = "StatisticPeriodType";
        internal const string _str_StatisticAreaType = "StatisticAreaType";
        internal const string _str_AggregateCaseListItems = "AggregateCaseListItems";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfAggrCase, _formname = _str_idfAggrCase, _type = "Int64",
              _get_func = o => o.idfAggrCase,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfAggrCase != newval) o.idfAggrCase = newval; },
              _compare_func = (o, c, m) => {
                if (o.idfAggrCase != c.idfAggrCase || o.IsRIRPropChanged(_str_idfAggrCase, c)) 
                  m.Add(_str_idfAggrCase, o.ObjectIdent + _str_idfAggrCase, o.ObjectIdent2 + _str_idfAggrCase, o.ObjectIdent3 + _str_idfAggrCase, "Int64", 
                    o.idfAggrCase == null ? "" : o.idfAggrCase.ToString(),                  
                  o.IsReadOnly(_str_idfAggrCase), o.IsInvisible(_str_idfAggrCase), o.IsRequired(_str_idfAggrCase)); 
                  }
              }, 
        
            new field_info {
              _name = _str_idfsPeriodType, _formname = _str_idfsPeriodType, _type = "long?",
              _get_func = o => o.idfsPeriodType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsPeriodType != newval) o.idfsPeriodType = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsPeriodType != c.idfsPeriodType || o.IsRIRPropChanged(_str_idfsPeriodType, c)) {
                  m.Add(_str_idfsPeriodType, o.ObjectIdent + _str_idfsPeriodType, o.ObjectIdent2 + _str_idfsPeriodType, o.ObjectIdent3 + _str_idfsPeriodType,  "long?", 
                    o.idfsPeriodType == null ? "" : o.idfsPeriodType.ToString(),                  
                    o.IsReadOnly(_str_idfsPeriodType), o.IsInvisible(_str_idfsPeriodType), o.IsRequired(_str_idfsPeriodType));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsAreaType, _formname = _str_idfsAreaType, _type = "long?",
              _get_func = o => o.idfsAreaType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsAreaType != newval) o.idfsAreaType = newval; },
              _compare_func = (o, c, m) => {
              
                if (o.idfsAreaType != c.idfsAreaType || o.IsRIRPropChanged(_str_idfsAreaType, c)) {
                  m.Add(_str_idfsAreaType, o.ObjectIdent + _str_idfsAreaType, o.ObjectIdent2 + _str_idfsAreaType, o.ObjectIdent3 + _str_idfsAreaType,  "long?", 
                    o.idfsAreaType == null ? "" : o.idfsAreaType.ToString(),                  
                    o.IsReadOnly(_str_idfsAreaType), o.IsInvisible(_str_idfsAreaType), o.IsRequired(_str_idfsAreaType));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_StatisticPeriodType, _formname = _str_StatisticPeriodType, _type = "Lookup",
              _get_func = o => { if (o.StatisticPeriodType == null) return null; return o.StatisticPeriodType.idfsBaseReference; },
              _set_func = (o, val) => { o.StatisticPeriodType = o.StatisticPeriodTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsPeriodType != c.idfsPeriodType || o.IsRIRPropChanged(_str_StatisticPeriodType, c)) {
                  m.Add(_str_StatisticPeriodType, o.ObjectIdent + _str_StatisticPeriodType, o.ObjectIdent2 + _str_StatisticPeriodType, o.ObjectIdent3 + _str_StatisticPeriodType, "Lookup", o.idfsPeriodType == null ? "" : o.idfsPeriodType.ToString(), o.IsReadOnly(_str_StatisticPeriodType), o.IsInvisible(_str_StatisticPeriodType), o.IsRequired(_str_StatisticPeriodType)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_StatisticPeriodType + "Lookup", _formname = _str_StatisticPeriodType + "Lookup", _type = "LookupContent",
              _get_func = o => o.StatisticPeriodTypeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_StatisticAreaType, _formname = _str_StatisticAreaType, _type = "Lookup",
              _get_func = o => { if (o.StatisticAreaType == null) return null; return o.StatisticAreaType.idfsBaseReference; },
              _set_func = (o, val) => { o.StatisticAreaType = o.StatisticAreaTypeLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsAreaType != c.idfsAreaType || o.IsRIRPropChanged(_str_StatisticAreaType, c)) {
                  m.Add(_str_StatisticAreaType, o.ObjectIdent + _str_StatisticAreaType, o.ObjectIdent2 + _str_StatisticAreaType, o.ObjectIdent3 + _str_StatisticAreaType, "Lookup", o.idfsAreaType == null ? "" : o.idfsAreaType.ToString(), o.IsReadOnly(_str_StatisticAreaType), o.IsInvisible(_str_StatisticAreaType), o.IsRequired(_str_StatisticAreaType)); 
                  }
                }
              }, 
            new field_info {
              _name = _str_StatisticAreaType + "Lookup", _formname = _str_StatisticAreaType + "Lookup", _type = "LookupContent",
              _get_func = o => o.StatisticAreaTypeLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m) => { }, 
              }, 
        
            new field_info {
              _name = _str_AggregateCaseListItems, _formname = _str_AggregateCaseListItems, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.AggregateCaseListItems.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.AggregateCaseListItems.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m) => {
                if (o.AggregateCaseListItems.Count != c.AggregateCaseListItems.Count || o.IsReadOnly(_str_AggregateCaseListItems) != c.IsReadOnly(_str_AggregateCaseListItems) || o.IsInvisible(_str_AggregateCaseListItems) != c.IsInvisible(_str_AggregateCaseListItems) || o.IsRequired(_str_AggregateCaseListItems) != c._isRequired(o.m_isRequired, _str_AggregateCaseListItems)) {
                  m.Add(_str_AggregateCaseListItems, o.ObjectIdent + _str_AggregateCaseListItems, o.ObjectIdent2 + _str_AggregateCaseListItems, o.ObjectIdent3 + _str_AggregateCaseListItems, "Child", o.idfAggrCase == null ? "" : o.idfAggrCase.ToString(), o.IsReadOnly(_str_AggregateCaseListItems), o.IsInvisible(_str_AggregateCaseListItems), o.IsRequired(_str_AggregateCaseListItems)); 
                  }
                }
              }, 
        
            new field_info()
        };
        #endregion
        
        private string _getType(string name)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            return i == null ? "" : i._type;
        }
        private object _getValue(string name)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            return i == null ? null : i._get_func(this);
        }
        private void _setValue(string name, string val)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            if (i != null) i._set_func(this, val);
        }
        internal CompareModel _compare(IObject o, CompareModel ret)
        {
            if (ret == null) ret = new CompareModel();
            if (o == null) return ret;
            VetAggregateCaseSummary obj = (VetAggregateCaseSummary)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_AggregateCaseListItems)]
        [Relation(typeof(VetAggregateCaseListItem), "", _str_idfAggrCase)]
        public EditableList<VetAggregateCaseListItem> AggregateCaseListItems
        {
            get 
            {   
                return _AggregateCaseListItems; 
            }
            set 
            {
                _AggregateCaseListItems = value;
            }
        }
        protected EditableList<VetAggregateCaseListItem> _AggregateCaseListItems = new EditableList<VetAggregateCaseListItem>();
                    
        [LocalizedDisplayName(_str_StatisticPeriodType)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsPeriodType)]
        public BaseReference StatisticPeriodType
        {
            get { return _StatisticPeriodType == null ? null : ((long)_StatisticPeriodType.Key == 0 ? null : _StatisticPeriodType); }
            set 
            { 
                var oldVal = _StatisticPeriodType;
                _StatisticPeriodType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_StatisticPeriodType != oldVal)
                {
                    if (idfsPeriodType != (_StatisticPeriodType == null
                            ? new long?()
                            : _StatisticPeriodType.idfsBaseReference))
                        idfsPeriodType = _StatisticPeriodType == null 
                            ? new long?()
                            : _StatisticPeriodType.idfsBaseReference; 
                    OnPropertyChanged(_str_StatisticPeriodType); 
                }
            }
        }
        private BaseReference _StatisticPeriodType;

        
        public BaseReferenceList StatisticPeriodTypeLookup
        {
            get { return _StatisticPeriodTypeLookup; }
        }
        private BaseReferenceList _StatisticPeriodTypeLookup = new BaseReferenceList("rftStatisticPeriodType");
            
        [LocalizedDisplayName(_str_StatisticAreaType)]
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsAreaType)]
        public BaseReference StatisticAreaType
        {
            get { return _StatisticAreaType == null ? null : ((long)_StatisticAreaType.Key == 0 ? null : _StatisticAreaType); }
            set 
            { 
                var oldVal = _StatisticAreaType;
                _StatisticAreaType = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_StatisticAreaType != oldVal)
                {
                    if (idfsAreaType != (_StatisticAreaType == null
                            ? new long?()
                            : _StatisticAreaType.idfsBaseReference))
                        idfsAreaType = _StatisticAreaType == null 
                            ? new long?()
                            : _StatisticAreaType.idfsBaseReference; 
                    OnPropertyChanged(_str_StatisticAreaType); 
                }
            }
        }
        private BaseReference _StatisticAreaType;

        
        public BaseReferenceList StatisticAreaTypeLookup
        {
            get { return _StatisticAreaTypeLookup; }
        }
        private BaseReferenceList _StatisticAreaTypeLookup = new BaseReferenceList("rftStatisticAreaType");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_StatisticPeriodType:
                    return new BvSelectList(StatisticPeriodTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, StatisticPeriodType, _str_idfsPeriodType);
            
                case _str_StatisticAreaType:
                    return new BvSelectList(StatisticAreaTypeLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, StatisticAreaType, _str_idfsAreaType);
            
                case _str_AggregateCaseListItems:
                    return new BvSelectList(AggregateCaseListItems, "", "", null, "");
            
            }
        
            return null;
        }
    
          [LocalizedDisplayName(_str_idfsPeriodType)]
        public long? idfsPeriodType
        {
            get { return m_idfsPeriodType; }
            set { if (m_idfsPeriodType != value) { m_idfsPeriodType = value; OnPropertyChanged(_str_idfsPeriodType); } }
        }
        private long? m_idfsPeriodType;
        
          [LocalizedDisplayName(_str_idfsAreaType)]
        public long? idfsAreaType
        {
            get { return m_idfsAreaType; }
            set { if (m_idfsAreaType != value) { m_idfsAreaType = value; OnPropertyChanged(_str_idfsAreaType); } }
        }
        private long? m_idfsAreaType;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "VetAggregateCaseSummary";

        #region Parent and Clone supporting
        [XmlIgnore]
        public IObject Parent
        {
            get { return m_Parent; }
            set { m_Parent = value; /*OnPropertyChanged(_str_Parent);*/ }
        }
        private IObject m_Parent;
        internal void _setParent()
        {
        AggregateCaseListItems.ForEach(c => { c.Parent = this; });
                
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        public override object Clone()
        {
            var ret = base.Clone() as VetAggregateCaseSummary;
            ret.Cloned();
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret._setParent();
            if (this.IsDirty && !ret.IsDirty)
                ret.SetChange();
            else if (!this.IsDirty && ret.IsDirty)
                ret.RejectChanges();
            return ret;
        }
        public IObject CloneWithSetup(DbManagerProxy manager, bool bRestricted = false)
        {
            var ret = base.Clone() as VetAggregateCaseSummary;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_AggregateCaseListItems != null && _AggregateCaseListItems.Count > 0)
            {
              ret.AggregateCaseListItems.Clear();
              _AggregateCaseListItems.ForEach(c => ret.AggregateCaseListItems.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public VetAggregateCaseSummary CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as VetAggregateCaseSummary;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfAggrCase; } }
        public string KeyName { get { return "idfAggrCase"; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        [XmlIgnore]
        [LocalizedDisplayName("HasChanges")]
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                    || AggregateCaseListItems.IsDirty
                    || AggregateCaseListItems.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfsPeriodType_StatisticPeriodType = idfsPeriodType;
            var _prev_idfsAreaType_StatisticAreaType = idfsAreaType;
            base.RejectChanges();
        
            if (_prev_idfsPeriodType_StatisticPeriodType != idfsPeriodType)
            {
                _StatisticPeriodType = _StatisticPeriodTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsPeriodType);
            }
            if (_prev_idfsAreaType_StatisticAreaType != idfsAreaType)
            {
                _StatisticAreaType = _StatisticAreaTypeLookup.FirstOrDefault(c => c.idfsBaseReference == idfsAreaType);
            }
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        AggregateCaseListItems.DeepRejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        AggregateCaseListItems.DeepAcceptChanges();
                
        }
        private bool m_bForceDirty;
        public override void AcceptChanges()
        {
            m_bForceDirty = false;
            base.AcceptChanges();
        }
        [XmlIgnore]
        [LocalizedDisplayName("IsDirty")]
        public override bool IsDirty
        {
            get { return m_bForceDirty || base.IsDirty; }
        }
        public void SetChange()
        { 
            m_bForceDirty = true;
        }
        public void DeepSetChange()
        { 
            SetChange();
        AggregateCaseListItems.ForEach(c => c.SetChange());
                
        }
        public bool MarkToDelete() { return _Delete(false); }
        public string ObjectName { get { return m_ObjectName; } }
        public string ObjectIdent { get { return ObjectName + "_" + Key.ToString() + "_"; } }
        
        public string ObjectIdent2 { get { return ObjectIdent; } }
          
        public string ObjectIdent3 { get { return ObjectIdent; } }
          
        public IObjectAccessor GetAccessor() { return _getAccessor(); }
        public IObjectPermissions GetPermissions() { return _permissions; }
        private IObjectEnvironment _environment;
        public IObjectEnvironment Environment { get { return _environment; } set { _environment = value; } }
        public bool ReadOnly { get { return _readOnly; } set { _readOnly = value; } }
        public bool IsReadOnly(string name) { return _isReadOnly(name); }
        public bool IsInvisible(string name) { return _isInvisible(name); }
        public bool IsRequired(string name) { return _isRequired(m_isRequired, name); }
        public bool IsHiddenPersonalData(string name) { return _isHiddenPersonalData(name); }
        public string GetType(string name) { return _getType(name); }
        public object GetValue(string name) { return _getValue(name); }
        public void SetValue(string name, string val) { _setValue(name, val); }
        public CompareModel Compare(IObject o) { return _compare(o, null); }
        public BvSelectList GetList(string name) { return _getList(name); }
        public event ValidationEvent Validation;
        public event ValidationEvent ValidationEnd;
        public event AfterPostEvent AfterPost;
      
        public Dictionary<string, string> GetFieldTags(string name)
        {
          return null;
        }
      #endregion

        private bool IsRIRPropChanged(string fld, VetAggregateCaseSummary c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }

      

        public VetAggregateCaseSummary()
        {
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();
        partial void ParsedFormCollection(NameValueCollection form);

        

        private bool m_IsForcedToDelete;
        [LocalizedDisplayName("IsForcedToDelete")]
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        [LocalizedDisplayName("IsMarkedToDelete")]
        public bool IsMarkedToDelete { get { return m_IsMarkedToDelete; } }

        public void _SetupMainHandler()
        {
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(VetAggregateCaseSummary_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(VetAggregateCaseSummary_PropertyChanged);
        }
        private void VetAggregateCaseSummary_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as VetAggregateCaseSummary).Changed(e.PropertyName);
            
        }
        
        public bool ForceToDelete() { return _Delete(true); }
        internal bool _Delete(bool isForceDelete)
        {
            if (!_ValidateOnDelete()) return false;
            _DeletingExtenders();
            m_IsMarkedToDelete = true;
            m_IsForcedToDelete = m_IsForcedToDelete ? m_IsForcedToDelete : isForceDelete;
            OnPropertyChanged("IsMarkedToDelete");
            _DeletedExtenders();
            Deleted();
            return true;
        }
        private bool _ValidateOnDelete(bool bReport = true)
        {
            
            return true;                
              
        }
        private void _DeletingExtenders()
        {
            VetAggregateCaseSummary obj = this;
            
        }
        private void _DeletedExtenders()
        {
            VetAggregateCaseSummary obj = this;
            
        }
        
        public bool OnValidation(ValidationModelException ex)
        {
            if (Validation != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ShouldAsk);
                Validation(this, args);
                return args.Continue;
            }
            return false;
        }
        public bool OnValidationEnd(ValidationModelException ex)
        {
            if (ValidationEnd != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ShouldAsk);
                ValidationEnd(this, args);
                return args.Continue;
            }
            return false;
        }

        public void OnAfterPost()
        {
            if (AfterPost != null)
            {
                AfterPost(this, EventArgs.Empty);
            }
        }

        public FormSize FormSize
        {
            get { return FormSize.Undefined; }
        }
    
        private bool _isInvisible(string name)
        {
            
            return false;
                
        }

    
        private bool _isReadOnly(string name)
        {
            
            return ReadOnly;
                
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                foreach(var o in _AggregateCaseListItems)
                    o.ReadOnly |= value;
                
            }
        }


        internal Dictionary<string, Func<VetAggregateCaseSummary, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<VetAggregateCaseSummary, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<VetAggregateCaseSummary, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<VetAggregateCaseSummary, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<VetAggregateCaseSummary, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<VetAggregateCaseSummary, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<VetAggregateCaseSummary, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~VetAggregateCaseSummary()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                AggregateCaseListItems.ForEach(c => c.Dispose());
                
                LookupManager.RemoveObject("rftStatisticPeriodType", this);
                
                LookupManager.RemoveObject("rftStatisticAreaType", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftStatisticPeriodType")
                _getAccessor().LoadLookup_StatisticPeriodType(manager, this);
            
            if (lookup_object == "rftStatisticAreaType")
                _getAccessor().LoadLookup_StatisticAreaType(manager, this);
            
        }
        #endregion
    
        public void ParseFormCollection(NameValueCollection form, bool bParseLookups = true, bool bParseRelations = true)
        {
            if (bParseLookups)
            {
                _field_infos.Where(i => i._type == "Lookup").ToList().ForEach(a => { if (form[ObjectIdent + a._formname] != null) a._set_func(this, form[ObjectIdent + a._formname]);} );
            }
            
            _field_infos.Where(i => i._type != "Lookup" && i._type != "Child" && i._type != "Relation" && i._type != null)
                .ToList().ForEach(a => { if (form.AllKeys.Contains(ObjectIdent + a._formname)) a._set_func(this, form[ObjectIdent + a._formname]);} );
      
            if (bParseRelations)
            {
        
            if (_AggregateCaseListItems != null) _AggregateCaseListItems.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<VetAggregateCaseSummary>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<VetAggregateCaseSummary>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<VetAggregateCaseSummary>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfAggrCase"; } }
            #endregion
        
            private delegate void on_action(VetAggregateCaseSummary obj);
            private static Accessor g_Instance = CreateInstance<Accessor>();
            private CacheScope m_CS;
            public static Accessor Instance(CacheScope cs) 
            { 
                if (cs == null)
                    return g_Instance;
                lock(cs)
                {
                    object acc = cs.Get(typeof (Accessor));
                    if (acc != null)
                    {
                        return acc as Accessor;
                    }
                    Accessor ret = CreateInstance<Accessor>();
                    ret.m_CS = cs;
                    cs.Add(typeof(Accessor), ret);
                    return ret;
                }
            }
            private VetAggregateCaseListItem.Accessor AggregateCaseListItemsAccessor { get { return eidss.model.Schema.VetAggregateCaseListItem.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor StatisticPeriodTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            private BaseReference.Accessor StatisticAreaTypeAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }
            public virtual VetAggregateCaseSummary SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNewT(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }

            
            public virtual VetAggregateCaseSummary SelectByKey(DbManagerProxy manager
                , Int64? idfAggrCase
                )
            {
                return _SelectByKey(manager
                    , idfAggrCase
                    , null, null
                    );
            }
            
      
            private VetAggregateCaseSummary _SelectByKey(DbManagerProxy manager
                , Int64? idfAggrCase
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<VetAggregateCaseSummary> objs = new List<VetAggregateCaseSummary>();
                sets[0] = new MapResultSet(typeof(VetAggregateCaseSummary), objs);
                
        
                try
                {
                    manager
                        .SetSpCommand("spAggregateCaseDummy_SelectDetail"
                            , manager.Parameter("@idfAggrCase", idfAggrCase)
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    VetAggregateCaseSummary obj = objs[0];
                    obj.m_CS = m_CS;
                    
                    if (loading != null)
                        loading(obj);
                    _SetupLoad(manager, obj);
                    
                    //obj._setParent();
                    if (loaded != null)
                        loaded(obj);
                    obj.Loaded(manager);
                    return obj;
                }
                catch(DataException e)
                {
                    throw DbModelException.Create(e);
                }
                
            }
    
            private void _SetupAddChildHandlerAggregateCaseListItems(VetAggregateCaseSummary obj)
            {
                obj.AggregateCaseListItems.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach(var o in e.NewItems)
                        {
                            _SetupChildHandlers(obj, o);
                        }
                    }
                };
            }
            
            internal void _LoadAggregateCaseListItems(VetAggregateCaseSummary obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadAggregateCaseListItems(manager, obj);
                }
            }
            internal void _LoadAggregateCaseListItems(DbManagerProxy manager, VetAggregateCaseSummary obj)
            {
                
            }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, VetAggregateCaseSummary obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                _LoadAggregateCaseListItems(manager, obj);
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupAddChildHandlerAggregateCaseListItems(obj);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, VetAggregateCaseSummary obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                        obj.AggregateCaseListItems.ForEach(c => AggregateCaseListItemsAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private VetAggregateCaseSummary _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                try
                {
                    VetAggregateCaseSummary obj = VetAggregateCaseSummary.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.idfAggrCase = (new GetNewIDExtender<VetAggregateCaseSummary>()).GetScalar(manager, obj, isFake);
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    _SetupAddChildHandlerAggregateCaseListItems(obj);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                    // created extenters - end
        
                    if (created != null)
                        created(obj);
                    obj.Created(manager);
                    _SetPermitions(obj._permissions, obj);
                    _SetupRequired(obj);
                    _SetupPersonalDataRestrictions(obj);
                    return obj;
                }
                catch(DataException e)
                {
                    throw DbModelException.Create(e);
                }
            }

            
            public VetAggregateCaseSummary CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public VetAggregateCaseSummary CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public VetAggregateCaseSummary CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult Select(DbManagerProxy manager, VetAggregateCaseSummary obj, List<object> pars)
            {
                
                return Select(manager, obj
                    );
            }
            public ActResult Select(DbManagerProxy manager, VetAggregateCaseSummary obj
                )
            {
                
                return true;
                
            }
            
      
            public ActResult RemoveAll(DbManagerProxy manager, VetAggregateCaseSummary obj, List<object> pars)
            {
                
                return RemoveAll(manager, obj
                    );
            }
            public ActResult RemoveAll(DbManagerProxy manager, VetAggregateCaseSummary obj
                )
            {
                
                return true;
                
            }
            
      
            public ActResult ShowSummaryInfo(DbManagerProxy manager, VetAggregateCaseSummary obj, List<object> pars)
            {
                
                return ShowSummaryInfo(manager, obj
                    );
            }
            public ActResult ShowSummaryInfo(DbManagerProxy manager, VetAggregateCaseSummary obj
                )
            {
                
                return true;
                
            }
            
      
            public ActResult PaperForm(DbManagerProxy manager, VetAggregateCaseSummary obj, List<object> pars)
            {
                
                return PaperForm(manager, obj
                    );
            }
            public ActResult PaperForm(DbManagerProxy manager, VetAggregateCaseSummary obj
                )
            {
                
                return true;
                
            }
            
      
            private void _SetupChildHandlers(VetAggregateCaseSummary obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(VetAggregateCaseSummary obj)
            {
                
            }
    
            public void LoadLookup_StatisticPeriodType(DbManagerProxy manager, VetAggregateCaseSummary obj)
            {
                
                obj.StatisticPeriodTypeLookup.Clear();
                
                obj.StatisticPeriodTypeLookup.Add(StatisticPeriodTypeAccessor.CreateNewT(manager, null));
                
                obj.StatisticPeriodTypeLookup.AddRange(StatisticPeriodTypeAccessor.rftStatisticPeriodType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsPeriodType))
                    
                    .ToList());
                
                if (obj.idfsPeriodType != null && obj.idfsPeriodType != 0)
                {
                    obj.StatisticPeriodType = obj.StatisticPeriodTypeLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsPeriodType);
                    
                }
              
                
                LookupManager.AddObject("rftStatisticPeriodType", obj, StatisticPeriodTypeAccessor.GetType(), "rftStatisticPeriodType_SelectList"
                  , "SelectLookupList");
            }
            
            public void LoadLookup_StatisticAreaType(DbManagerProxy manager, VetAggregateCaseSummary obj)
            {
                
                obj.StatisticAreaTypeLookup.Clear();
                
                obj.StatisticAreaTypeLookup.Add(StatisticAreaTypeAccessor.CreateNewT(manager, null));
                
                obj.StatisticAreaTypeLookup.AddRange(StatisticAreaTypeAccessor.rftStatisticAreaType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsAreaType))
                    
                    .ToList());
                
                if (obj.idfsAreaType != null && obj.idfsAreaType != 0)
                {
                    obj.StatisticAreaType = obj.StatisticAreaTypeLookup
                        .SingleOrDefault(c => c.idfsBaseReference == obj.idfsAreaType);
                    
                }
              
                
                LookupManager.AddObject("rftStatisticAreaType", obj, StatisticAreaTypeAccessor.GetType(), "rftStatisticAreaType_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, VetAggregateCaseSummary obj)
            {
                
                LoadLookup_StatisticPeriodType(manager, obj);
                
                LoadLookup_StatisticAreaType(manager, obj);
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(VetAggregateCaseSummary obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(VetAggregateCaseSummary obj, bool bRethrowException)
            {
                ValidationModelException ex = ChainsValidate(obj);
                if (ex != null)
                {
                    if (bRethrowException)
                        throw ex;
                    if (!obj.OnValidation(ex))
                    {
                        obj.OnValidationEnd(ex);
                        return false;
                    }
                }
                return true;
            }
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as VetAggregateCaseSummary, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, VetAggregateCaseSummary obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                try
                {
                    if (bPostValidation)
                    {
                
                (new RequiredValidator( "idfsPeriodType", "StatisticPeriodType","",
                false
              )).Validate(c => true, obj, obj.idfsPeriodType);
            
                (new RequiredValidator( "idfsAreaType", "StatisticAreaType","",
                false
              )).Validate(c => true, obj, obj.idfsAreaType);
            
                  
                    }

                    if (bChangeValidation)
                    {
                
                    }
                    
                    if (bDeepValidation)
                    {
                
                    }
                }
                catch(ValidationModelException ex)
                {
                    if (bRethrowException)
                        throw;
                    if (!obj.OnValidation(ex))
                    {
                        obj.OnValidationEnd(ex);
                        return false;
                    }
                }
                
                return true;
            }
           
    
            private void _SetupRequired(VetAggregateCaseSummary obj)
            {
            
                obj
                    .AddRequired("StatisticPeriodType", c => true);
                    
                  obj
                    .AddRequired("StatisticPeriodType", c => true);
                
                obj
                    .AddRequired("StatisticAreaType", c => true);
                    
                  obj
                    .AddRequired("StatisticAreaType", c => true);
                
            }
    
    private void _SetupPersonalDataRestrictions(VetAggregateCaseSummary obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as VetAggregateCaseSummary) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as VetAggregateCaseSummary) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "VetAggregateCaseSummaryDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return "VC_V11"; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spAggregateCaseDummy_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<VetAggregateCaseSummary, bool>> RequiredByField = new Dictionary<string, Func<VetAggregateCaseSummary, bool>>();
            public static Dictionary<string, Func<VetAggregateCaseSummary, bool>> RequiredByProperty = new Dictionary<string, Func<VetAggregateCaseSummary, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            
            
    private static Dictionary<string, List<Func<bool>>> m_isHiddenPersonalData = new Dictionary<string, List<Func<bool>>>();
    internal static bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData.ContainsKey(name))
          return m_isHiddenPersonalData[name].Aggregate(false, (s,c) => s | c());
      return false;
    }

    private static void AddHiddenPersonalData(string name, Func<bool> func)
    {
      if (!m_isHiddenPersonalData.ContainsKey(name))
          m_isHiddenPersonalData.Add(name, new List<Func<bool>>());
      m_isHiddenPersonalData[name].Add(func);
    }
  
            
            static Meta()
            {
                
                if (!RequiredByField.ContainsKey("idfsPeriodType")) RequiredByField.Add("idfsPeriodType", c => true);
                if (!RequiredByProperty.ContainsKey("StatisticPeriodType")) RequiredByProperty.Add("StatisticPeriodType", c => true);
                
                if (!RequiredByField.ContainsKey("idfsAreaType")) RequiredByField.Add("idfsAreaType", c => true);
                if (!RequiredByProperty.ContainsKey("StatisticAreaType")) RequiredByProperty.Add("StatisticAreaType", c => true);
                
                Actions.Add(new ActionMetaItem(
                    "Select",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).Select(manager, (VetAggregateCaseSummary)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSelect_Id",
                        "",
                        /*from BvMessages*/"strSelect_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                        ),
                      true,
                    null,
                    null,
                    null,
                    null,
                    null,
                    false,
                    false,
                    "aggregateSummary.selectVetAggrCase",
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "RemoveAll",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).RemoveAll(manager, (VetAggregateCaseSummary)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strRemoveAll_Id",
                        "",
                        /*from BvMessages*/"strRemoveAll_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                        ),
                      true,
                    null,
                    null,
                    null,
                    null,
                    null,
                    false,
                    false,
                    "aggregateSummary.removeAllFromAggrCase",
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "ShowSummaryInfo",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).ShowSummaryInfo(manager, (VetAggregateCaseSummary)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strShowSummaryInfo_Id",
                        "",
                        /*from BvMessages*/"strShowSummaryInfo_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                        ),
                      true,
                    null,
                    null,
                    null,
                    null,
                    null,
                    false,
                    false,
                    "aggregateSummary.showSummaryInfoAggrCase",
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "PaperForm",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).PaperForm(manager, (VetAggregateCaseSummary)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strReport_Id",
                        "",
                        /*from BvMessages*/"strReport_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                        ),
                      true,
                    null,
                    null,
                    null,
                    null,
                    null,
                    false,
                    false,
                    "aggregateSummary.printAggrCase",
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
        
                _SetupPersonalDataRestrictions();
            }
            
            
    private static void _SetupPersonalDataRestrictions()
    {
    

    }
  
        }
        #endregion
    

        #endregion
        }
    
}
	