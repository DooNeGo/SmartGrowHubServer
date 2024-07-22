﻿// <auto-generated />
using System;
using System.Collections;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartGrowHubServer.Domain.Model;
using SmartGrowHubServer.Infrastructure.Data.Convertors;
using SmartGrowHubServer.Infrastructure.Data.Model;

#pragma warning disable 219, 612, 618
#nullable disable

namespace SmartGrowHubServer.Infrastructure.Data.CompiledModels
{
    internal partial class SettingDbEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "SmartGrowHubServer.Infrastructure.Data.Model.SettingDb",
                typeof(SettingDb),
                baseEntityType);

            var id = runtimeEntityType.AddProperty(
                "Id",
                typeof(Ulid),
                propertyInfo: typeof(SettingDb).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(SettingDb).GetField("<Id>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                afterSaveBehavior: PropertySaveBehavior.Throw,
                valueConverter: new UlidConverter());
            id.TypeMapping = SqlServerByteArrayTypeMapping.Default.Clone(
                comparer: new ValueComparer<Ulid>(
                    (Ulid v1, Ulid v2) => v1.Equals(v2),
                    (Ulid v) => v.GetHashCode(),
                    (Ulid v) => v),
                keyComparer: new ValueComparer<Ulid>(
                    (Ulid v1, Ulid v2) => v1.Equals(v2),
                    (Ulid v) => v.GetHashCode(),
                    (Ulid v) => v),
                providerValueComparer: new ValueComparer<byte[]>(
                    (Byte[] v1, Byte[] v2) => StructuralComparisons.StructuralEqualityComparer.Equals((object)v1, (object)v2),
                    (Byte[] v) => StructuralComparisons.StructuralEqualityComparer.GetHashCode((object)v),
                    (Byte[] source) => source.ToArray()),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "varbinary(16)",
                    size: 16),
                converter: new ValueConverter<Ulid, byte[]>(
                    (Ulid model) => model.ToByteArray(),
                    (Byte[] provider) => new Ulid((ReadOnlySpan<byte>)provider)),
                jsonValueReaderWriter: new JsonConvertedValueReaderWriter<Ulid, byte[]>(
                    JsonByteArrayReaderWriter.Instance,
                    new ValueConverter<Ulid, byte[]>(
                        (Ulid model) => model.ToByteArray(),
                        (Byte[] provider) => new Ulid((ReadOnlySpan<byte>)provider))));
            id.SetSentinelFromProviderValue(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            id.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var growHubId = runtimeEntityType.AddProperty(
                "GrowHubId",
                typeof(Ulid),
                propertyInfo: typeof(SettingDb).GetProperty("GrowHubId", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(SettingDb).GetField("<GrowHubId>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueConverter: new UlidConverter());
            growHubId.TypeMapping = SqlServerByteArrayTypeMapping.Default.Clone(
                comparer: new ValueComparer<Ulid>(
                    (Ulid v1, Ulid v2) => v1.Equals(v2),
                    (Ulid v) => v.GetHashCode(),
                    (Ulid v) => v),
                keyComparer: new ValueComparer<Ulid>(
                    (Ulid v1, Ulid v2) => v1.Equals(v2),
                    (Ulid v) => v.GetHashCode(),
                    (Ulid v) => v),
                providerValueComparer: new ValueComparer<byte[]>(
                    (Byte[] v1, Byte[] v2) => StructuralComparisons.StructuralEqualityComparer.Equals((object)v1, (object)v2),
                    (Byte[] v) => StructuralComparisons.StructuralEqualityComparer.GetHashCode((object)v),
                    (Byte[] source) => source.ToArray()),
                mappingInfo: new RelationalTypeMappingInfo(
                    storeTypeName: "varbinary(16)",
                    size: 16),
                converter: new ValueConverter<Ulid, byte[]>(
                    (Ulid model) => model.ToByteArray(),
                    (Byte[] provider) => new Ulid((ReadOnlySpan<byte>)provider)),
                jsonValueReaderWriter: new JsonConvertedValueReaderWriter<Ulid, byte[]>(
                    JsonByteArrayReaderWriter.Instance,
                    new ValueConverter<Ulid, byte[]>(
                        (Ulid model) => model.ToByteArray(),
                        (Byte[] provider) => new Ulid((ReadOnlySpan<byte>)provider))));
            growHubId.SetSentinelFromProviderValue(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            growHubId.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var mode = runtimeEntityType.AddProperty(
                "Mode",
                typeof(SettingMode),
                propertyInfo: typeof(SettingDb).GetProperty("Mode", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(SettingDb).GetField("<Mode>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            mode.TypeMapping = IntTypeMapping.Default.Clone(
                comparer: new ValueComparer<SettingMode>(
                    (SettingMode v1, SettingMode v2) => object.Equals((object)v1, (object)v2),
                    (SettingMode v) => v.GetHashCode(),
                    (SettingMode v) => v),
                keyComparer: new ValueComparer<SettingMode>(
                    (SettingMode v1, SettingMode v2) => object.Equals((object)v1, (object)v2),
                    (SettingMode v) => v.GetHashCode(),
                    (SettingMode v) => v),
                providerValueComparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v),
                converter: new ValueConverter<SettingMode, int>(
                    (SettingMode value) => (int)value,
                    (int value) => (SettingMode)value),
                jsonValueReaderWriter: new JsonConvertedValueReaderWriter<SettingMode, int>(
                    JsonInt32ReaderWriter.Instance,
                    new ValueConverter<SettingMode, int>(
                        (SettingMode value) => (int)value,
                        (int value) => (SettingMode)value)));
            mode.SetSentinelFromProviderValue(0);
            mode.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var type = runtimeEntityType.AddProperty(
                "Type",
                typeof(SettingType),
                propertyInfo: typeof(SettingDb).GetProperty("Type", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(SettingDb).GetField("<Type>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            type.TypeMapping = IntTypeMapping.Default.Clone(
                comparer: new ValueComparer<SettingType>(
                    (SettingType v1, SettingType v2) => object.Equals((object)v1, (object)v2),
                    (SettingType v) => v.GetHashCode(),
                    (SettingType v) => v),
                keyComparer: new ValueComparer<SettingType>(
                    (SettingType v1, SettingType v2) => object.Equals((object)v1, (object)v2),
                    (SettingType v) => v.GetHashCode(),
                    (SettingType v) => v),
                providerValueComparer: new ValueComparer<int>(
                    (int v1, int v2) => v1 == v2,
                    (int v) => v,
                    (int v) => v),
                converter: new ValueConverter<SettingType, int>(
                    (SettingType value) => (int)value,
                    (int value) => (SettingType)value),
                jsonValueReaderWriter: new JsonConvertedValueReaderWriter<SettingType, int>(
                    JsonInt32ReaderWriter.Instance,
                    new ValueConverter<SettingType, int>(
                        (SettingType value) => (int)value,
                        (int value) => (SettingType)value)));
            type.SetSentinelFromProviderValue(0);
            type.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var key = runtimeEntityType.AddKey(
                new[] { id });
            runtimeEntityType.SetPrimaryKey(key);

            var index = runtimeEntityType.AddIndex(
                new[] { growHubId });

            return runtimeEntityType;
        }

        public static RuntimeForeignKey CreateForeignKey1(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("GrowHubId") },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("Id") }),
                principalEntityType,
                deleteBehavior: DeleteBehavior.Cascade,
                required: true);

            var growHub = declaringEntityType.AddNavigation("GrowHub",
                runtimeForeignKey,
                onDependent: true,
                typeof(GrowHubDb),
                propertyInfo: typeof(SettingDb).GetProperty("GrowHub", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(SettingDb).GetField("<GrowHub>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var settings = principalEntityType.AddNavigation("Settings",
                runtimeForeignKey,
                onDependent: false,
                typeof(ImmutableArray<SettingDb>),
                propertyInfo: typeof(GrowHubDb).GetProperty("Settings", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(GrowHubDb).GetField("<Settings>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            return runtimeForeignKey;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "Settings");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
