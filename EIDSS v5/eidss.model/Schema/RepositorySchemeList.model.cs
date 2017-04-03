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
    public abstract partial class RepositorySchemeListItem : 
        EditableObject<RepositorySchemeListItem>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfFreezer), NonUpdatable, PrimaryKey]
        public abstract Int64 idfFreezer { get; set; }
                
        [LocalizedDisplayName(_str_strFreezerName)]
        [MapField(_str_strFreezerName)]
        public abstract String strFreezerName { get; set; }
        #if MONO
        protected String strFreezerName_Original { get { return strFreezerName; } }
        protected String strFreezerName_Previous { get { return strFreezerName; } }
        #else
        protected String strFreezerName_Original { get { return ((EditableValue<String>)((dynamic)this)._strFreezerName).OriginalValue; } }
        protected String strFreezerName_Previous { get { return ((EditableValue<String>)((dynamic)this)._strFreezerName).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName("RepositoryScheme.strNote")]
        [MapField(_str_strNote)]
        public abstract String strNote { get; set; }
        #if MONO
        protected String strNote_Original { get { return strNote; } }
        protected String strNote_Previous { get { return strNote; } }
        #else
        protected String strNote_Original { get { return ((EditableValue<String>)((dynamic)this)._strNote).OriginalValue; } }
        protected String strNote_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNote).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_idfsStorageType)]
        [MapField(_str_idfsStorageType)]
        public abstract Int64? idfsStorageType { get; set; }
        #if MONO
        protected Int64? idfsStorageType_Original { get { return idfsStorageType; } }
        protected Int64? idfsStorageType_Previous { get { return idfsStorageType; } }
        #else
        protected Int64? idfsStorageType_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsStorageType).OriginalValue; } }
        protected Int64? idfsStorageType_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfsStorageType).PreviousValue; } }
        #endif
                
        [LocalizedDisplayName(_str_StorageType)]
        [MapField(_str_StorageType)]
        public abstract String StorageType { get; set; }
        #if MONO
        protected String StorageType_Original { get { return StorageType; } }
        protected String StorageType_Previous { get { return StorageType; } }
        #else
        protected String StorageType_Original { get { return ((EditableValue<String>)((dynamic)this)._storageType).OriginalValue; } }
        protected String StorageType_Previous { get { return ((EditableValue<String>)((dynamic)this)._storageType).PreviousValue; } }
        #endif
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _type;
            internal Func<RepositorySchemeListItem, object> _get_func;
            internal Action<RepositorySchemeListItem, string> _set_func;
            internal Action<RepositorySchemeListItem, RepositorySchemeListItem, CompareModel> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfFreezer = "idfFreezer";
        internal const string _str_strFreezerName = "strFreezerName";
        internal const string _str_strNote = "strNote";
        internal const string _str_idfsStorageType = "idfsStorageType";
        internal const string _str_StorageType = "StorageType";
        internal const string _str_Storage = "Storage";
        private static readonly field_info[] _field_infos =
        {
        
            new field_info {
              _name = _str_idfFreezer, _type = "Int64",
              _get_func = o => o.idfFreezer,
              _set_func = (o, val) => { o.idfFreezer = ParsingHelper.ParseInt64(val); },
              _compare_func = (o, c, m) => {
                if (o.idfFreezer != c.idfFreezer || o.IsRIRPropChanged(_str_idfFreezer, c)) 
                  m.Add(_str_idfFreezer, o.ObjectIdent + _str_idfFreezer, "Int64", o.idfFreezer == null ? "" : o.idfFreezer.ToString(), o.IsReadOnly(_str_idfFreezer), o.IsInvisible(_str_idfFreezer), o.IsRequired(_str_idfFreezer)); }
              }, 
        
            new field_info {
              _name = _str_strFreezerName, _type = "String",
              _get_func = o => o.strFreezerName,
              _set_func = (o, val) => { o.strFreezerName = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strFreezerName != c.strFreezerName || o.IsRIRPropChanged(_str_strFreezerName, c)) 
                  m.Add(_str_strFreezerName, o.ObjectIdent + _str_strFreezerName, "String", o.strFreezerName == null ? "" : o.strFreezerName.ToString(), o.IsReadOnly(_str_strFreezerName), o.IsInvisible(_str_strFreezerName), o.IsRequired(_str_strFreezerName)); }
              }, 
        
            new field_info {
              _name = _str_strNote, _type = "String",
              _get_func = o => o.strNote,
              _set_func = (o, val) => { o.strNote = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.strNote != c.strNote || o.IsRIRPropChanged(_str_strNote, c)) 
                  m.Add(_str_strNote, o.ObjectIdent + _str_strNote, "String", o.strNote == null ? "" : o.strNote.ToString(), o.IsReadOnly(_str_strNote), o.IsInvisible(_str_strNote), o.IsRequired(_str_strNote)); }
              }, 
        
            new field_info {
              _name = _str_idfsStorageType, _type = "Int64?",
              _get_func = o => o.idfsStorageType,
              _set_func = (o, val) => { o.idfsStorageType = ParsingHelper.ParseInt64Nullable(val); },
              _compare_func = (o, c, m) => {
                if (o.idfsStorageType != c.idfsStorageType || o.IsRIRPropChanged(_str_idfsStorageType, c)) 
                  m.Add(_str_idfsStorageType, o.ObjectIdent + _str_idfsStorageType, "Int64?", o.idfsStorageType == null ? "" : o.idfsStorageType.ToString(), o.IsReadOnly(_str_idfsStorageType), o.IsInvisible(_str_idfsStorageType), o.IsRequired(_str_idfsStorageType)); }
              }, 
        
            new field_info {
              _name = _str_StorageType, _type = "String",
              _get_func = o => o.StorageType,
              _set_func = (o, val) => { o.StorageType = ParsingHelper.ParseString(val); },
              _compare_func = (o, c, m) => {
                if (o.StorageType != c.StorageType || o.IsRIRPropChanged(_str_StorageType, c)) 
                  m.Add(_str_StorageType, o.ObjectIdent + _str_StorageType, "String", o.StorageType == null ? "" : o.StorageType.ToString(), o.IsReadOnly(_str_StorageType), o.IsInvisible(_str_StorageType), o.IsRequired(_str_StorageType)); }
              }, 
        
            new field_info {
              _name = _str_Storage, _type = "Lookup",
              _get_func = o => { if (o.Storage == null) return null; return o.Storage.idfsBaseReference; },
              _set_func = (o, val) => { o.Storage = o.StorageLookup.Where(c => c.idfsBaseReference.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m) => {
                if (o.idfsStorageType != c.idfsStorageType || o.IsRIRPropChanged(_str_Storage, c)) 
                  m.Add(_str_Storage, o.ObjectIdent + _str_Storage, "Lookup", o.idfsStorageType == null ? "" : o.idfsStorageType.ToString(), o.IsReadOnly(_str_Storage), o.IsInvisible(_str_Storage), o.IsRequired(_str_Storage)); }
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
            RepositorySchemeListItem obj = (RepositorySchemeListItem)o;
            foreach (var i in _field_infos)
                if (i != null && i._compare_func != null) i._compare_func(this, obj, ret);
            return ret;
        }
        #endregion
    
        [Relation(typeof(BaseReference), eidss.model.Schema.BaseReference._str_idfsBaseReference, _str_idfsStorageType)]
        public BaseReference Storage
        {
            get { return _Storage == null ? null : ((long)_Storage.Key == 0 ? null : _Storage); }
            set 
            { 
                _Storage = value == null ? null : ((long) value.Key == 0 ? null : value);
                idfsStorageType = _Storage == null 
                    ? new Int64?()
                    : _Storage.idfsBaseReference; 
                OnPropertyChanged(_str_Storage); 
            }
        }
        private BaseReference _Storage;

        
        public BaseReferenceList StorageLookup
        {
            get { return _StorageLookup; }
        }
        private BaseReferenceList _StorageLookup = new BaseReferenceList("rftStorageType");
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Storage:
                    return new BvSelectList(StorageLookup, eidss.model.Schema.BaseReference._str_idfsBaseReference, null, Storage, _str_idfsStorageType);
            
            }
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "RepositorySchemeListItem";

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
        
        }
        public override object Clone()
        {
            var ret = base.Clone() as RepositorySchemeListItem;
            ret.m_Parent = this.Parent;
            ret._setParent();
            if (this.IsDirty && !ret.IsDirty)
                ret.SetChange();
            else if (!this.IsDirty && ret.IsDirty)
                ret.RejectChanges();
            return ret;
        }
        public IObject CloneWithSetup(DbManagerProxy manager)
        {
            var ret = base.Clone() as RepositorySchemeListItem;
            ret.m_Parent = this.Parent;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor acc = Accessor.Instance(null);
            acc._SetupLoad(manager, ret);
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public RepositorySchemeListItem CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as RepositorySchemeListItem;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfFreezer; } }
        public string KeyName { get { return "idfFreezer"; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfsStorageType_Storage = idfsStorageType;
            base.RejectChanges();
        
            if (_prev_idfsStorageType_Storage != idfsStorageType)
            {
                _Storage = _StorageLookup.FirstOrDefault(c => c.idfsBaseReference == idfsStorageType);
            }
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
        }
        private bool m_bForceDirty;
        public override void AcceptChanges()
        {
            m_bForceDirty = false;
            base.AcceptChanges();
        }
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
        
        }
        public bool MarkToDelete() { return _Delete(false); }
        public string ObjectName { get { return m_ObjectName; } }
        public string ObjectIdent { get { return ObjectName + "_" + Key.ToString() + "_"; } }
      public IObjectAccessor GetAccessor() { return _getAccessor(); }
      public IObjectPermissions GetPermissions() { return _permissions; }
      public bool ReadOnly { get { return _readOnly; } set { _readOnly = value; } }
      public bool IsReadOnly(string name) { return _isReadOnly(name); }
      public bool IsInvisible(string name) { return _isInvisible(name); }
      public bool IsRequired(string name) { return _isRequired(name); }
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

      private bool IsRIRPropChanged(string fld, RepositorySchemeListItem c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c.IsRequired(fld);
        }

      

        public RepositorySchemeListItem()
        {
            
            m_permissions = new Permissions(this);
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();

        

        private bool m_IsForcedToDelete;
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        public bool IsMarkedToDelete { get { return m_IsMarkedToDelete; } }

        public void _SetupMainHandler()
        {
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(RepositorySchemeListItem_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(RepositorySchemeListItem_PropertyChanged);
        }
        private void RepositorySchemeListItem_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as RepositorySchemeListItem).Changed(e.PropertyName);
            
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
            
            return Accessor.Instance(null).ValidateCanDelete(this);
              
        }
        private void _DeletingExtenders()
        {
            RepositorySchemeListItem obj = this;
            
        }
        private void _DeletedExtenders()
        {
            RepositorySchemeListItem obj = this;
            
        }
        
        public bool OnValidation(string msgId, string fldName, string prpName, object[] pars, Type type, bool shouldAsk)
        {
            if (Validation != null)
            {
                var args = new ValidationEventArgs(msgId, fldName, prpName, pars, type, this, shouldAsk);
                Validation(this, args);
                return args.Continue;
            }
            return false;
        }
        public bool OnValidationEnd(string msgId, string fldName, string prpName, object[] pars, Type type, bool shouldAsk)
        {
            if (ValidationEnd != null)
            {
                var args = new ValidationEventArgs(msgId, fldName, prpName, pars, type, this, shouldAsk);
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
        
            }
        }


        public Dictionary<string, Func<RepositorySchemeListItem, bool>> m_isRequired;
        private bool _isRequired(string name)
        {
            if (m_isRequired != null && m_isRequired.ContainsKey(name))
                return m_isRequired[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<RepositorySchemeListItem, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<RepositorySchemeListItem, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    public Dictionary<string, Func<RepositorySchemeListItem, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
    if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
    return m_isHiddenPersonalData[name](this);
    return false;
    }

    public void AddHiddenPersonalData(string name, Func<RepositorySchemeListItem, bool> func)
    {
    if (m_isHiddenPersonalData == null)
    m_isHiddenPersonalData = new Dictionary<string, Func<RepositorySchemeListItem, bool>>();
    if (!m_isHiddenPersonalData.ContainsKey(name))
    m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        private bool bIsDisposed;
        ~RepositorySchemeListItem()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                
                LookupManager.RemoveObject("rftStorageType", this);
                
            }
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "rftStorageType")
                _getAccessor().LoadLookup_Storage(manager, this);
            
        }
        #endregion
    
        public void ParseFormCollection(NameValueCollection form, bool bParseLookups = true, bool bParseRelations = true)
        {
            if (bParseLookups)
            {
                _field_infos.Where(i => i._type == "Lookup").ToList().ForEach(a => { if (form[ObjectIdent + a._name] != null) a._set_func(this, form[ObjectIdent + a._name]);} );
            }
            
            _field_infos.Where(i => i._type != "Lookup" && i._type != "Child" && i._type != "Relation" && i._type != null)
                .ToList().ForEach(a => { if (form.AllKeys.Contains(ObjectIdent + a._name)) a._set_func(this, form[ObjectIdent + a._name]);} );
      
            if (bParseRelations)
            {
        
            }
        }
    
        #region Class for web grid
        public class RepositorySchemeListItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfFreezer { get; set; }
        
            public String strFreezerName { get; set; }
        
            public String strNote { get; set; }
        
            public String StorageType { get; set; }
        
        }
        public partial class RepositorySchemeListItemGridModelList : List<RepositorySchemeListItemGridModel>, IGridModelList
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public RepositorySchemeListItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<RepositorySchemeListItem>, errMes);
            }
            public RepositorySchemeListItemGridModelList(long key, IEnumerable<RepositorySchemeListItem> items)
            {
                LoadGridModelList(key, items, null);
            }
            partial void filter(List<RepositorySchemeListItem> items);
            private void LoadGridModelList(long key, IEnumerable<RepositorySchemeListItem> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_strFreezerName,_str_strNote,_str_StorageType};
                    
                Hiddens = new List<string> {_str_idfFreezer};
                Keys = new List<string> {_str_idfFreezer};
                Labels = new Dictionary<string, string> {{_str_strFreezerName, _str_strFreezerName},{_str_strNote, "RepositoryScheme.strNote"},{_str_StorageType, _str_StorageType}};
                Actions = new Dictionary<string, ActionMetaItem> {};
                var list = new List<RepositorySchemeListItem>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new RepositorySchemeListItemGridModel()
                {
                    ItemKey=c.idfFreezer,strFreezerName=c.strFreezerName,strNote=c.strNote,StorageType=c.StorageType
                }));
                if (Count > 0)
                {
                    this.Last().ErrorMessage = errMes;
                }
            }
        }
        #endregion
        

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<RepositorySchemeListItem>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectPermissions
            
            , IObjectCreator
            
            , IObjectSelectList
                    
            , IObjectPost
                    
        {
            private delegate void on_action(RepositorySchemeListItem obj);
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
            private BaseReference.Accessor StorageAccessor { get { return eidss.model.Schema.BaseReference.Accessor.Instance(m_CS); } }
            
            public virtual List<RepositorySchemeListItem> SelectListT(DbManagerProxy manager
                , FilterParams filters = null
                , KeyValuePair<string, ListSortDirection>[] sorts = null
                , bool serverSort = false
                )
            {
                return _SelectList(manager
                , null, null
                , filters
                , sorts
                , serverSort
                );
            }
            public virtual List<IObject> SelectList(DbManagerProxy manager
                , FilterParams filters = null
                , KeyValuePair<string, ListSortDirection>[] sorts = null
                , bool serverSort = false
                )
            {
                return _SelectList(manager
                , null, null
                , filters
                , sorts
                , serverSort
                ).Cast<IObject>().ToList();
            }
            
            private List<RepositorySchemeListItem> _SelectList(DbManagerProxy manager
                , on_action loading, on_action loaded
                , FilterParams filters
                , KeyValuePair<string, ListSortDirection>[] sorts
                , bool serverSort = false
                )
            {
                if (filters == null) filters = new FilterParams();
                var sql = new StringBuilder();
                string maxtop = BaseSettings.SelectTopMaxCount.ToString();
                sql.Append(@"select ");
                
                sql.Append(@"top ");
                sql.Append(maxtop);
                sql.Append(@" dbo.fn_RepositoryScheme_SelectList.* from dbo.fn_RepositoryScheme_SelectList(@LangID
                    ) ");
                
                sql.Append(" where 0 = 0");
                
                if (filters.Contains("idfFreezer"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfFreezer"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfFreezer") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_RepositoryScheme_SelectList.idfFreezer,0) {0} @idfFreezer_{1}", filters.Operation("idfFreezer", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strFreezerName"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strFreezerName"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strFreezerName") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_RepositoryScheme_SelectList.strFreezerName {0} @strFreezerName_{1}", filters.Operation("strFreezerName", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("strNote"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("strNote"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("strNote") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_RepositoryScheme_SelectList.strNote {0} @strNote_{1}", filters.Operation("strNote", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("idfsStorageType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("idfsStorageType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("idfsStorageType") ? " or " : " and ");
                        
                        sql.AppendFormat("isnull(fn_RepositoryScheme_SelectList.idfsStorageType,0) {0} @idfsStorageType_{1}", filters.Operation("idfsStorageType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (filters.Contains("StorageType"))
                {
                    sql.AppendFormat(" and (");
                    for (int i = 0; i < filters.Count("StorageType"); i++)
                    {
                        if (i > 0) 
                          sql.AppendFormat(filters.IsOr("StorageType") ? " or " : " and ");
                        
                        sql.AppendFormat("fn_RepositoryScheme_SelectList.StorageType {0} @StorageType_{1}", filters.Operation("StorageType", i), i);
                            
                    }
                    sql.AppendFormat(")");
                }
                  
                if (serverSort && sorts != null && sorts.Length > 0)
                {
                    sql.Append(" order by");
                    bool bFirst = true;
                    foreach(var sort in sorts)
                    {
                        sql.Append((bFirst ? " " : ", ") + sort.Key + " " + (sort.Value == ListSortDirection.Ascending ? "ASC" : "DESC"));
                        bFirst = false;
                    }
                }

                bool bTransactionStarted = false;
                try
                {
                    if (!manager.IsTransactionStarted)
                    {
                        bTransactionStarted = true;
                        manager.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
                    }
                    manager
                        .SetCommand(sql.ToString()
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                        );
                    
                    if (filters.Contains("idfFreezer"))
                        for (int i = 0; i < filters.Count("idfFreezer"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfFreezer_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfFreezer", i), filters.Value("idfFreezer", i))));
                      
                    if (filters.Contains("strFreezerName"))
                        for (int i = 0; i < filters.Count("strFreezerName"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strFreezerName_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strFreezerName", i), filters.Value("strFreezerName", i))));
                      
                    if (filters.Contains("strNote"))
                        for (int i = 0; i < filters.Count("strNote"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@strNote_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("strNote", i), filters.Value("strNote", i))));
                      
                    if (filters.Contains("idfsStorageType"))
                        for (int i = 0; i < filters.Count("idfsStorageType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@idfsStorageType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("idfsStorageType", i), filters.Value("idfsStorageType", i))));
                      
                    if (filters.Contains("StorageType"))
                        for (int i = 0; i < filters.Count("StorageType"); i++)
                            manager.SelectCommand.Parameters.Add(manager.InputParameter("@StorageType_" + i, ParsingHelper.CorrectLikeValue(filters.Operation("StorageType", i), filters.Value("StorageType", i))));
                      
                    List<RepositorySchemeListItem> objs = manager.ExecuteList<RepositorySchemeListItem>();
                    if (bTransactionStarted)
                    {
                        manager.CommitTransaction();
                    }
                    return objs;
                }
                catch(DataException e)
                {
                    if (bTransactionStarted)
                    {
                        manager.RollbackTransaction();
                    }
                    throw DbModelException.Create(e);
                }
            }
            
            public virtual long? SelectCount(DbManagerProxy manager)
            {
                
                return _selectCount(manager);
                    
            }
        
            [SprocName("spRepositoryScheme_SelectCount")]
            protected abstract long? _selectCount(DbManagerProxy manager);
        
        
        
            internal void _SetupLoad(DbManagerProxy manager, RepositorySchemeListItem obj)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, RepositorySchemeListItem obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private RepositorySchemeListItem _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created)
            {
                try
                {
                    RepositorySchemeListItem obj = RepositorySchemeListItem.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
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

            
            public RepositorySchemeListItem CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            
            public RepositorySchemeListItem CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult Copy(DbManagerProxy manager, RepositorySchemeListItem obj, List<object> pars)
            {
                
                if (pars.Count != 3) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is object)) 
                    throw new TypeMismatchException("key", typeof(object));
                if (pars[1] != null && !(pars[1] is IObject)) 
                    throw new TypeMismatchException("item", typeof(IObject));
                if (pars[2] != null && !(pars[2] is object)) 
                    throw new TypeMismatchException("listPanel", typeof(object));
                
                return Copy(manager, obj
                    , (object)pars[0]
                    , (IObject)pars[1]
                    , (object)pars[2]
                    );
            }
            public ActResult Copy(DbManagerProxy manager, RepositorySchemeListItem obj
                , object key
                , IObject item
                , object listPanel
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("Copy"))
                    throw new PermissionException("RepositoryScheme", "Copy");
                
                return true;
                
            }
            
            public ActResult CopyFreezer(DbManagerProxy manager, RepositorySchemeListItem obj, List<object> pars)
            {
                
                if (pars.Count != 2) 
                    throw new ParamsCountException();
                if (pars[0] != null && !(pars[0] is long)) 
                    throw new TypeMismatchException("key", typeof(long));
                if (pars[1] != null && !(pars[1] is string)) 
                    throw new TypeMismatchException("freezerName", typeof(string));
                
                return CopyFreezer(manager, obj
                    , (long)pars[0]
                    , (string)pars[1]
                    );
            }
            public ActResult CopyFreezer(DbManagerProxy manager, RepositorySchemeListItem obj
                , long key
                , string freezerName
                )
            {
                
                if (obj != null && !obj.GetPermissions().CanExecute("CopyFreezer"))
                    throw new PermissionException("RepositoryScheme", "CopyFreezer");
                
              manager.SetSpCommand("dbo.spRepositoryScheme_CopyFreezer"
                , manager.Parameter("idfFreezer", key)
                , manager.Parameter("strFreezerName", freezerName)
                ).ExecuteNonQuery();
              return true;
            
            }
            
            private void _SetupChildHandlers(RepositorySchemeListItem obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(RepositorySchemeListItem obj)
            {
                
            }
    
            public void LoadLookup_Storage(DbManagerProxy manager, RepositorySchemeListItem obj)
            {
                
                obj.StorageLookup.Clear();
                
                obj.StorageLookup.Add(StorageAccessor.CreateNewT(manager, null));
                
                obj.StorageLookup.AddRange(StorageAccessor.rftStorageType_SelectList(manager
                    
                    )
                    .Where(c => (c.intRowStatus == 0) || (c.idfsBaseReference == obj.idfsStorageType))
                    
                    .ToList());
                
                if (obj.idfsStorageType != null && obj.idfsStorageType != 0)
                {
                    obj.Storage = obj.StorageLookup
                        .Where(c => c.idfsBaseReference == obj.idfsStorageType)
                        .SingleOrDefault();
                }
              
                
                LookupManager.AddObject("rftStorageType", obj, StorageAccessor.GetType(), "rftStorageType_SelectList"
                  , "SelectLookupList");
            }
            

            private void _LoadLookups(DbManagerProxy manager, RepositorySchemeListItem obj)
            {
                
                LoadLookup_Storage(manager, obj);
                
            }
    
            [SprocName("spRepositoryScheme_CanDelete")]
            protected abstract void _canDelete(DbManagerProxy manager, Int64? ID, out Boolean Result
                );
        
            [SprocName("spRepositoryScheme_Delete")]
            protected abstract void _postDelete(DbManagerProxy manager
                , Int64? ID
                );
            protected void _postDeletePredicate(DbManagerProxy manager
                , Int64? ID
                )
            {
                
                _postDelete(manager, ID);
                
            }
        
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bTransactionStarted = false;
                bool bSuccess;
                try
                {
                    RepositorySchemeListItem bo = obj as RepositorySchemeListItem;
                    
                    if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                    {
                        if (!bo.GetPermissions().CanDelete)
                            throw new PermissionException("RepositoryScheme", "Delete");
                    }
                    else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        if (!bo.GetPermissions().CanInsert)
                            throw new PermissionException("RepositoryScheme", "Insert");
                    }
                    else if (!bo.IsMarkedToDelete) // update
                    {
                        if (!bo.GetPermissions().CanUpdate)
                            throw new PermissionException("RepositoryScheme", "Update");
                    }
                    
                
                    if (!manager.IsTransactionStarted)
                    {
                        
                        eidss.model.Enums.AuditEventType auditEventType = eidss.model.Enums.AuditEventType.daeFreeDataUpdate;
                        
                        long mainObject = bo.idfFreezer;
                        
                        if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                        {
                            
                            auditEventType = eidss.model.Enums.AuditEventType.daeDelete;
                            
                        }
                        else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                        {
                            
                            auditEventType = eidss.model.Enums.AuditEventType.daeCreate;
                            
                        }
                        else if (!bo.IsMarkedToDelete) // update
                        {
                            
                            auditEventType = eidss.model.Enums.AuditEventType.daeEdit;
                            
                        }
                        
                        eidss.model.Enums.EIDSSAuditObject objectType = eidss.model.Enums.EIDSSAuditObject.daoRepositoryScheme;
                        eidss.model.Enums.AuditTable auditTable = eidss.model.Enums.AuditTable.tlbFreezer;
                        manager.AuditParams = new object[] { auditEventType, objectType, auditTable, mainObject };
                        
                        bTransactionStarted = true;
                        manager.BeginTransaction();
                    }
                    bSuccess = _PostNonTransaction(manager, obj as RepositorySchemeListItem, bChildObject);
                    if (bTransactionStarted)
                    {
                        if (bSuccess)
                        {
                            manager.CommitTransaction();
                            
                        }
                        else
                        {
                            manager.RollbackTransaction();
                        }
                        
                    }
                    if (bSuccess && bo.IsNew && !bo.IsMarkedToDelete) // insert
                    {
                        bo.m_IsNew = false;
                    }
                    if (bSuccess && bTransactionStarted)
                    {
                        bo.OnAfterPost();
                    }
                }
                catch(Exception e)
                {
                    if (bTransactionStarted)
                    {
                        manager.RollbackTransaction();
                        
                    }
                    
                    if (e is DataException)
                    {
                        throw DbModelException.Create(e as DataException);
                    }
                    else 
                        throw;
                }
                return bSuccess;
            }
            private bool _PostNonTransaction(DbManagerProxy manager, RepositorySchemeListItem obj, bool bChildObject) 
            { 
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                    _postDeletePredicate(manager
                        , obj.idfFreezer
                        );
                                    
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                }
                obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(RepositorySchemeListItem obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, RepositorySchemeListItem obj)
            {
            
                try
                {
                    if (!obj.IsForcedToDelete)
                    {
                        bool result = false;
                        _canDelete(manager
                            , obj.idfFreezer
                            , out result
                            );
                        if (!result) 
                        {
                            throw new ValidationModelException("msgCantDelete", "_on_delete", "_on_delete", null, null, false);
                        }
                     }
                }
                catch(ValidationModelException ex)
                {
                    if (!obj.OnValidation(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk))
                    {
                        obj.OnValidationEnd(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.ShouldAsk);
                        return false;
                    }
                    else
                        obj.m_IsForcedToDelete = true;
                }
            
                return true;
            }
        
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as RepositorySchemeListItem, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, RepositorySchemeListItem obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                
                return true;
            }
           
    
            #region IObjectPermissions
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("RepositoryScheme.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("RepositoryScheme.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("RepositoryScheme.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("RepositoryScheme.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !CanUpdate; } }
            #endregion
            
            private void _SetupRequired(RepositorySchemeListItem obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(RepositorySchemeListItem obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as RepositorySchemeListItem) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as RepositorySchemeListItem) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "RepositorySchemeListItemDetail"; } }
            public string HelpIdWin { get { return "RepositoryScheme"; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            #endregion
    
        }

        
            #region IObjectPermissions
        internal class Permissions : IObjectPermissions
        {
            private RepositorySchemeListItem m_obj;
            internal Permissions(RepositorySchemeListItem obj)
            {
                m_obj = obj;
            }
            
            public bool CanSelect { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("RepositoryScheme.Select"); } }
            public bool CanUpdate { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("RepositoryScheme.Update"); } }
            public bool CanDelete { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("RepositoryScheme.Delete"); } }
            public bool CanInsert { get { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo("RepositoryScheme.Insert"); } }
            
            public bool CanExecute(string permission) { return ModelUserContext.Instance == null ? true : ModelUserContext.Instance.CanDo(permission.Contains(".") ? permission : permission + ".Execute"); }
            public bool IsReadOnlyForEdit { get { return !(CanUpdate || (CanInsert && m_obj.IsNew)); } }
        }
            #endregion
            
        #region Meta
        public static class Meta
        {
            public static string spSelect = "fn_RepositoryScheme_SelectList";
            public static string spCount = "spRepositoryScheme_SelectCount";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "spRepositoryScheme_Delete";
            public static string spCanDelete = "spRepositoryScheme_CanDelete";
        
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<RepositorySchemeListItem, bool>> RequiredByField = new Dictionary<string, Func<RepositorySchemeListItem, bool>>();
            public static Dictionary<string, Func<RepositorySchemeListItem, bool>> RequiredByProperty = new Dictionary<string, Func<RepositorySchemeListItem, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            static Meta()
            {
                
                Sizes.Add(_str_strFreezerName, 200);
                Sizes.Add(_str_strNote, 200);
                Sizes.Add(_str_StorageType, 2000);
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strFreezerName",
                    EditorType.Text,
                    false, false, 
                    "strFreezerName",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "strNote",
                    EditorType.Text,
                    false, false, 
                    "RepositoryScheme.strNote",
                    null, null, false, false, SearchPanelLocation.Main, false, null, null, null, null, null
                    ));
                SearchPanelMeta.Add(new SearchPanelMetaItem(
                    "idfsStorageType",
                    EditorType.Lookup,
                    false, false, 
                    "StorageType",
                    null, null, false, false, SearchPanelLocation.Main, false, null, "StorageLookup", typeof(BaseReference), (o) => { var c = (BaseReference)o; return c.idfsBaseReference; }, (o) => { var c = (BaseReference)o; return c.name; }
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_idfFreezer,
                    _str_idfFreezer, null, false, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strFreezerName,
                    _str_strFreezerName, null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strNote,
                    "RepositoryScheme.strNote", null, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_StorageType,
                    _str_StorageType, null, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "Copy",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).Copy(manager, (RepositorySchemeListItem)c, pars),
                        
                    null,
                    
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCopy_Id",
                        "",
                        /*from BvMessages*/"strCopy_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                        ),
                      false,
                    null,
                    null,
                    (c, p, b) => c != null,
                    null,
                    null,
                    false
                    ));
                
                Actions.Add(new ActionMetaItem(
                    "CopyFreezer",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).CopyFreezer(manager, (RepositorySchemeListItem)c, pars),
                        
                    null,
                    
                    null,
                      false,
                    null,
                    null,
                    null,
                    null,
                    null,
                    false
                    ));
                
                Actions.Add(new ActionMetaItem(
                    "SelectAll",
                    ActionTypes.SelectAll,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSelectAll_Id",
                        "selectall",
                        /*from BvMessages*/"tooltipSelectAll_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSelectAll_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Select",
                    ActionTypes.Select,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSelect_Id",
                        "select",
                        /*from BvMessages*/"tooltipSelect_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSelect_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.CreatorInterface<RepositoryScheme>().CreateNew(manager, null, pars == null ? null : (int?)pars[0])),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCreate_Id",
                        "add",
                        /*from BvMessages*/"tooltipCreate_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipCreate_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Edit",
                    ActionTypes.Edit,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, ObjectAccessor.SelectDetailInterface<RepositoryScheme>().SelectDetail(manager, pars[0])),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strEdit_Id",
                        "edit",
                        /*from BvMessages*/"tooltipEdit_Id",
                        /*from BvMessages*/"strView_Id",
                        "View1",
                        /*from BvMessages*/"tooltipEdit_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => 
                        {
                            if (c == null)
                            {
                                c = ObjectAccessor.CreatorInterface<RepositorySchemeListItem>().CreateWithParams(manager, null, pars);
                                ((RepositorySchemeListItem)c).idfFreezer = (long)pars[0];
                                ((RepositorySchemeListItem)c).m_IsNew = false;
                            }
                            return new ActResult(((RepositorySchemeListItem)c).MarkToDelete() && ObjectAccessor.PostInterface<RepositorySchemeListItem>().Post(manager, (RepositorySchemeListItem)c), c);
                        }
                                            ,
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipDelete_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Top,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Refresh",
                    ActionTypes.Refresh,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strRefresh_Id",
                        "iconRefresh_Id",
                        /*from BvMessages*/"tooltipRefresh_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipRefresh_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Close",
                    ActionTypes.Close,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strClose_Id",
                        "Close",
                        /*from BvMessages*/"tooltipClose_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipClose_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Report",
                    ActionTypes.Report,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strReport_Id",
                        "Report",
                        /*from BvMessages*/"tooltipReport_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipReport_Id",
                        ActionsAlignment.Left,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
        
            }
        }
        #endregion
    

        #endregion
        }
    
}
	