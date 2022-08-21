﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wrt.services.shares
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ELDB")]
	public partial class dcShareDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertDivision(Division instance);
    partial void UpdateDivision(Division instance);
    partial void DeleteDivision(Division instance);
    partial void InsertEmp(Emp instance);
    partial void UpdateEmp(Emp instance);
    partial void DeleteEmp(Emp instance);
    partial void Insertchat(chat instance);
    partial void Updatechat(chat instance);
    partial void Deletechat(chat instance);
    #endregion
		
		public dcShareDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["ELDBConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public dcShareDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dcShareDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dcShareDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dcShareDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Division> Divisions
		{
			get
			{
				return this.GetTable<Division>();
			}
		}
		
		public System.Data.Linq.Table<Emp> Emps
		{
			get
			{
				return this.GetTable<Emp>();
			}
		}
		
		public System.Data.Linq.Table<chat> chats
		{
			get
			{
				return this.GetTable<chat>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Division")]
	public partial class Division : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Division_code;
		
		private string _Division_name;
		
		private char _Division_status;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnDivision_codeChanging(string value);
    partial void OnDivision_codeChanged();
    partial void OnDivision_nameChanging(string value);
    partial void OnDivision_nameChanged();
    partial void OnDivision_statusChanging(char value);
    partial void OnDivision_statusChanged();
    #endregion
		
		public Division()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Division_code", DbType="Char(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Division_code
		{
			get
			{
				return this._Division_code;
			}
			set
			{
				if ((this._Division_code != value))
				{
					this.OnDivision_codeChanging(value);
					this.SendPropertyChanging();
					this._Division_code = value;
					this.SendPropertyChanged("Division_code");
					this.OnDivision_codeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Division_name", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string Division_name
		{
			get
			{
				return this._Division_name;
			}
			set
			{
				if ((this._Division_name != value))
				{
					this.OnDivision_nameChanging(value);
					this.SendPropertyChanging();
					this._Division_name = value;
					this.SendPropertyChanged("Division_name");
					this.OnDivision_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Division_status", DbType="Char(1) NOT NULL")]
		public char Division_status
		{
			get
			{
				return this._Division_status;
			}
			set
			{
				if ((this._Division_status != value))
				{
					this.OnDivision_statusChanging(value);
					this.SendPropertyChanging();
					this._Division_status = value;
					this.SendPropertyChanged("Division_status");
					this.OnDivision_statusChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Emp")]
	public partial class Emp : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Emp_code;
		
		private string _Division_code;
		
		private string _Emp_name;
		
		private char _Emp_status;
		
		private double _Emp_salary;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnEmp_codeChanging(string value);
    partial void OnEmp_codeChanged();
    partial void OnDivision_codeChanging(string value);
    partial void OnDivision_codeChanged();
    partial void OnEmp_nameChanging(string value);
    partial void OnEmp_nameChanged();
    partial void OnEmp_statusChanging(char value);
    partial void OnEmp_statusChanged();
    partial void OnEmp_salaryChanging(double value);
    partial void OnEmp_salaryChanged();
    #endregion
		
		public Emp()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Emp_code", DbType="Char(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Emp_code
		{
			get
			{
				return this._Emp_code;
			}
			set
			{
				if ((this._Emp_code != value))
				{
					this.OnEmp_codeChanging(value);
					this.SendPropertyChanging();
					this._Emp_code = value;
					this.SendPropertyChanged("Emp_code");
					this.OnEmp_codeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Division_code", DbType="Char(10) NOT NULL", CanBeNull=false)]
		public string Division_code
		{
			get
			{
				return this._Division_code;
			}
			set
			{
				if ((this._Division_code != value))
				{
					this.OnDivision_codeChanging(value);
					this.SendPropertyChanging();
					this._Division_code = value;
					this.SendPropertyChanged("Division_code");
					this.OnDivision_codeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Emp_name", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string Emp_name
		{
			get
			{
				return this._Emp_name;
			}
			set
			{
				if ((this._Emp_name != value))
				{
					this.OnEmp_nameChanging(value);
					this.SendPropertyChanging();
					this._Emp_name = value;
					this.SendPropertyChanged("Emp_name");
					this.OnEmp_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Emp_status", DbType="Char(1) NOT NULL")]
		public char Emp_status
		{
			get
			{
				return this._Emp_status;
			}
			set
			{
				if ((this._Emp_status != value))
				{
					this.OnEmp_statusChanging(value);
					this.SendPropertyChanging();
					this._Emp_status = value;
					this.SendPropertyChanged("Emp_status");
					this.OnEmp_statusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Emp_salary", DbType="Float NOT NULL")]
		public double Emp_salary
		{
			get
			{
				return this._Emp_salary;
			}
			set
			{
				if ((this._Emp_salary != value))
				{
					this.OnEmp_salaryChanging(value);
					this.SendPropertyChanging();
					this._Emp_salary = value;
					this.SendPropertyChanged("Emp_salary");
					this.OnEmp_salaryChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.chat")]
	public partial class chat : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.DateTime _chat_date;
		
		private string _chat_from;
		
		private string _chat_to;
		
		private string _chat_msg;
		
		private int _chat_state;
		
		private System.DateTime _chat_update;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onchat_dateChanging(System.DateTime value);
    partial void Onchat_dateChanged();
    partial void Onchat_fromChanging(string value);
    partial void Onchat_fromChanged();
    partial void Onchat_toChanging(string value);
    partial void Onchat_toChanged();
    partial void Onchat_msgChanging(string value);
    partial void Onchat_msgChanged();
    partial void Onchat_stateChanging(int value);
    partial void Onchat_stateChanged();
    partial void Onchat_updateChanging(System.DateTime value);
    partial void Onchat_updateChanged();
    #endregion
		
		public chat()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_chat_date", DbType="DateTime NOT NULL", IsPrimaryKey=true)]
		public System.DateTime chat_date
		{
			get
			{
				return this._chat_date;
			}
			set
			{
				if ((this._chat_date != value))
				{
					this.Onchat_dateChanging(value);
					this.SendPropertyChanging();
					this._chat_date = value;
					this.SendPropertyChanged("chat_date");
					this.Onchat_dateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_chat_from", DbType="Char(10) NOT NULL", CanBeNull=false)]
		public string chat_from
		{
			get
			{
				return this._chat_from;
			}
			set
			{
				if ((this._chat_from != value))
				{
					this.Onchat_fromChanging(value);
					this.SendPropertyChanging();
					this._chat_from = value;
					this.SendPropertyChanged("chat_from");
					this.Onchat_fromChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_chat_to", DbType="Char(10) NOT NULL", CanBeNull=false)]
		public string chat_to
		{
			get
			{
				return this._chat_to;
			}
			set
			{
				if ((this._chat_to != value))
				{
					this.Onchat_toChanging(value);
					this.SendPropertyChanging();
					this._chat_to = value;
					this.SendPropertyChanged("chat_to");
					this.Onchat_toChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_chat_msg", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string chat_msg
		{
			get
			{
				return this._chat_msg;
			}
			set
			{
				if ((this._chat_msg != value))
				{
					this.Onchat_msgChanging(value);
					this.SendPropertyChanging();
					this._chat_msg = value;
					this.SendPropertyChanged("chat_msg");
					this.Onchat_msgChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_chat_state", DbType="Int NOT NULL")]
		public int chat_state
		{
			get
			{
				return this._chat_state;
			}
			set
			{
				if ((this._chat_state != value))
				{
					this.Onchat_stateChanging(value);
					this.SendPropertyChanging();
					this._chat_state = value;
					this.SendPropertyChanged("chat_state");
					this.Onchat_stateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_chat_update", DbType="DateTime NOT NULL")]
		public System.DateTime chat_update
		{
			get
			{
				return this._chat_update;
			}
			set
			{
				if ((this._chat_update != value))
				{
					this.Onchat_updateChanging(value);
					this.SendPropertyChanging();
					this._chat_update = value;
					this.SendPropertyChanged("chat_update");
					this.Onchat_updateChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
