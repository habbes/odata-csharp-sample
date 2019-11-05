﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generation date: 10/23/2019 11:12:57 PM
namespace OdataSamples.Models
{
    /// <summary>
    /// There are no comments for CarSingle in the schema.
    /// </summary>
    public partial class CarSingle : global::Microsoft.OData.Client.DataServiceQuerySingle<Car>
    {
        /// <summary>
        /// Initialize a new CarSingle object.
        /// </summary>
        public CarSingle(global::Microsoft.OData.Client.DataServiceContext context, string path)
            : base(context, path) {}

        /// <summary>
        /// Initialize a new CarSingle object.
        /// </summary>
        public CarSingle(global::Microsoft.OData.Client.DataServiceContext context, string path, bool isComposable)
            : base(context, path, isComposable) {}

        /// <summary>
        /// Initialize a new CarSingle object.
        /// </summary>
        public CarSingle(global::Microsoft.OData.Client.DataServiceQuerySingle<Car> query)
            : base(query) {}

    }
    /// <summary>
    /// There are no comments for Car in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Id
    /// </KeyProperties>
    [global::Microsoft.OData.Client.Key("Id")]
    public partial class Car : global::Microsoft.OData.Client.BaseEntityType
    {
        /// <summary>
        /// Create a new Car object.
        /// </summary>
        /// <param name="ID">Initial value of Id.</param>
        /// <param name="year">Initial value of Year.</param>
        /// <param name="value">Initial value of Value.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.6.0")]
        public static Car CreateCar(int ID, int year, double value)
        {
            Car car = new Car();
            car.Id = ID;
            car.Year = year;
            car.Value = value;
            return car;
        }
        /// <summary>
        /// There are no comments for Property Id in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.6.0")]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                this.OnIdChanging(value);
                this._Id = value;
                this.OnIdChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.6.0")]
        private int _Id;
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        /// <summary>
        /// There are no comments for Property Model in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.6.0")]
        public string Model
        {
            get
            {
                return this._Model;
            }
            set
            {
                this.OnModelChanging(value);
                this._Model = value;
                this.OnModelChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.6.0")]
        private string _Model;
        partial void OnModelChanging(string value);
        partial void OnModelChanged();
        /// <summary>
        /// There are no comments for Property Color in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.6.0")]
        public string Color
        {
            get
            {
                return this._Color;
            }
            set
            {
                this.OnColorChanging(value);
                this._Color = value;
                this.OnColorChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.6.0")]
        private string _Color;
        partial void OnColorChanging(string value);
        partial void OnColorChanged();
        /// <summary>
        /// There are no comments for Property Year in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.6.0")]
        public int Year
        {
            get
            {
                return this._Year;
            }
            set
            {
                this.OnYearChanging(value);
                this._Year = value;
                this.OnYearChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.6.0")]
        private int _Year;
        partial void OnYearChanging(int value);
        partial void OnYearChanged();
        /// <summary>
        /// There are no comments for Property Value in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.6.0")]
        public double Value
        {
            get
            {
                return this._Value;
            }
            set
            {
                this.OnValueChanging(value);
                this._Value = value;
                this.OnValueChanged();
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.6.0")]
        private double _Value;
        partial void OnValueChanging(double value);
        partial void OnValueChanged();
    }
    /// <summary>
    /// Class containing all extension methods
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Get an entity of type global::OdataSamples.Models.Car as global::OdataSamples.Models.CarSingle specified by key from an entity set
        /// </summary>
        /// <param name="source">source entity set</param>
        /// <param name="keys">dictionary with the names and values of keys</param>
        public static global::OdataSamples.Models.CarSingle ByKey(this global::Microsoft.OData.Client.DataServiceQuery<global::OdataSamples.Models.Car> source, global::System.Collections.Generic.Dictionary<string, object> keys)
        {
            return new global::OdataSamples.Models.CarSingle(source.Context, source.GetKeyPath(global::Microsoft.OData.Client.Serializer.GetKeyString(source.Context, keys)));
        }
        /// <summary>
        /// Get an entity of type global::OdataSamples.Models.Car as global::OdataSamples.Models.CarSingle specified by key from an entity set
        /// </summary>
        /// <param name="source">source entity set</param>
        /// <param name="id">The value of id</param>
        public static global::OdataSamples.Models.CarSingle ByKey(this global::Microsoft.OData.Client.DataServiceQuery<global::OdataSamples.Models.Car> source,
            int id)
        {
            global::System.Collections.Generic.Dictionary<string, object> keys = new global::System.Collections.Generic.Dictionary<string, object>
            {
                { "Id", id }
            };
            return new global::OdataSamples.Models.CarSingle(source.Context, source.GetKeyPath(global::Microsoft.OData.Client.Serializer.GetKeyString(source.Context, keys)));
        }
    }
}
namespace Default
{
    /// <summary>
    /// There are no comments for Container in the schema.
    /// </summary>
    public partial class Container : global::Microsoft.OData.Client.DataServiceContext
    {
        /// <summary>
        /// Initialize a new Container object.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.6.0")]
        public Container(global::System.Uri serviceRoot) : 
                base(serviceRoot, global::Microsoft.OData.Client.ODataProtocolVersion.V4)
        {
            this.ResolveName = new global::System.Func<global::System.Type, string>(this.ResolveNameFromType);
            this.OnContextCreated();
            this.Format.LoadServiceModel = GeneratedEdmModel.GetInstance;
            this.Format.UseJson();
        }
        partial void OnContextCreated();
        /// <summary>
        /// Since the namespace configured for this service reference
        /// in Visual Studio is different from the one indicated in the
        /// server schema, use type-mappers to map between the two.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.6.0")]
        protected string ResolveNameFromType(global::System.Type clientType)
        {
            return clientType.FullName;
        }
        /// <summary>
        /// There are no comments for Car in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.6.0")]
        public global::Microsoft.OData.Client.DataServiceQuery<global::OdataSamples.Models.Car> Car
        {
            get
            {
                if ((this._Car == null))
                {
                    this._Car = base.CreateQuery<global::OdataSamples.Models.Car>("Car");
                }
                return this._Car;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.6.0")]
        private global::Microsoft.OData.Client.DataServiceQuery<global::OdataSamples.Models.Car> _Car;
        /// <summary>
        /// There are no comments for Car in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.6.0")]
        public void AddToCar(global::OdataSamples.Models.Car car)
        {
            base.AddObject("Car", car);
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.6.0")]
        private abstract class GeneratedEdmModel
        {
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.6.0")]
            private static global::Microsoft.OData.Edm.IEdmModel ParsedModel = LoadModelFromString();
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.6.0")]
            private const string Edmx = @"<edmx:Edmx Version=""4.0"" xmlns:edmx=""http://docs.oasis-open.org/odata/ns/edmx"">
  <edmx:DataServices>
    <Schema Namespace=""OdataSamples.Models"" xmlns=""http://docs.oasis-open.org/odata/ns/edm"">
      <EntityType Name=""Car"">
        <Key>
          <PropertyRef Name=""Id"" />
        </Key>
        <Property Name=""Id"" Type=""Edm.Int32"" Nullable=""false"" />
        <Property Name=""Model"" Type=""Edm.String"" />
        <Property Name=""Color"" Type=""Edm.String"" />
        <Property Name=""Year"" Type=""Edm.Int32"" Nullable=""false"" />
        <Property Name=""Value"" Type=""Edm.Double"" Nullable=""false"" />
      </EntityType>
    </Schema>
    <Schema Namespace=""Default"" xmlns=""http://docs.oasis-open.org/odata/ns/edm"">
      <EntityContainer Name=""Container"">
        <EntitySet Name=""Car"" EntityType=""OdataSamples.Models.Car"" />
      </EntityContainer>
    </Schema>
  </edmx:DataServices>
</edmx:Edmx>";
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.6.0")]
            public static global::Microsoft.OData.Edm.IEdmModel GetInstance()
            {
                return ParsedModel;
            }
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.6.0")]
            private static global::Microsoft.OData.Edm.IEdmModel LoadModelFromString()
            {
                global::System.Xml.XmlReader reader = CreateXmlReader(Edmx);
                try
                {
                    global::System.Collections.Generic.IEnumerable<global::Microsoft.OData.Edm.Validation.EdmError> errors;
                    global::Microsoft.OData.Edm.IEdmModel edmModel;
                    
                    if (!global::Microsoft.OData.Edm.Csdl.CsdlReader.TryParse(reader, false, out edmModel, out errors))
                    {
                        global::System.Text.StringBuilder errorMessages = new System.Text.StringBuilder();
                        foreach (var error in errors)
                        {
                            errorMessages.Append(error.ErrorMessage);
                            errorMessages.Append("; ");
                        }
                        throw new global::System.InvalidOperationException(errorMessages.ToString());
                    }

                    return edmModel;
                }
                finally
                {
                    ((global::System.IDisposable)(reader)).Dispose();
                }
            }
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.6.0")]
            private static global::System.Xml.XmlReader CreateXmlReader(string edmxToParse)
            {
                return global::System.Xml.XmlReader.Create(new global::System.IO.StringReader(edmxToParse));
            }
        }
    }
}