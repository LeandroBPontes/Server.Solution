using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server.Data.Extensions;

internal static class MapExtension
{
    public static PropertyBuilder<Guid> MapUuid<T>(
        this EntityTypeBuilder<T> builder,
        Expression<Func<T, Guid>> exp,
        string columnName)
        where T : class
    {
        return builder.Property<Guid>(exp).HasColumnName<Guid>(columnName).HasColumnType<Guid>("uuid")
            .ValueGeneratedNever().IsRequired(true);
    }

    public static PropertyBuilder<Guid?> MapUuid<T>(
        this EntityTypeBuilder<T> builder,
        Expression<Func<T, Guid?>> exp,
        string columnName)
        where T : class
    {
        return builder.Property<Guid?>(exp).HasColumnName<Guid?>(columnName).ValueGeneratedNever()
            .HasColumnType<Guid?>("uuid");
    }

    public static PropertyBuilder<string> MapVarchar<T>(
        this EntityTypeBuilder<T> builder,
        Expression<Func<T, string>> exp,
        string columnName,
        int size,
        bool isRequired)
        where T : class
    {
        PropertyBuilder<string> propertyBuilder1 = builder.Property<string>(exp).HasColumnName<string>(columnName);
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
        interpolatedStringHandler.AppendLiteral("varchar(");
        interpolatedStringHandler.AppendFormatted<int>(size);
        interpolatedStringHandler.AppendLiteral(")");
        string stringAndClear = interpolatedStringHandler.ToStringAndClear();
        PropertyBuilder<string> propertyBuilder2 = propertyBuilder1.HasColumnType<string>(stringAndClear);
        return !isRequired ? propertyBuilder2 : propertyBuilder2.IsRequired(true);
    }

    public static PropertyBuilder<string> MapVarchar<T>(
        this EntityTypeBuilder<T> builder,
        Expression<Func<T, string>> exp,
        string columnName,
        bool isRequired)
        where T : class
    {
        PropertyBuilder<string> propertyBuilder = builder.Property<string>(exp).HasColumnName<string>(columnName)
            .HasColumnType<string>("varchar");
        return !isRequired ? propertyBuilder : propertyBuilder.IsRequired(true);
    }

    public static PropertyBuilder<Enum> MapEnumAsVarchar<T>(
        this EntityTypeBuilder<T> builder,
        Expression<Func<T, Enum>> exp,
        string columnName,
        int size,
        bool isRequired)
        where T : class
    {
        PropertyBuilder<Enum> propertyBuilder1 = builder.Property<Enum>(exp).HasColumnName<Enum>(columnName);
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
        interpolatedStringHandler.AppendLiteral("varchar(");
        interpolatedStringHandler.AppendFormatted<int>(size);
        interpolatedStringHandler.AppendLiteral(")");
        string stringAndClear = interpolatedStringHandler.ToStringAndClear();
        PropertyBuilder<Enum> propertyBuilder2 =
            propertyBuilder1.HasColumnType<Enum>(stringAndClear).HasConversion<string>();
        return !isRequired ? propertyBuilder2 : propertyBuilder2.IsRequired(true);
    }

    public static PropertyBuilder<string> MapText<T>(
        this EntityTypeBuilder<T> builder,
        Expression<Func<T, string>> exp,
        string columnName,
        bool isRequired)
        where T : class
    {
        PropertyBuilder<string> propertyBuilder = builder.Property<string>(exp).HasColumnName<string>(columnName)
            .HasColumnType<string>("text");
        return !isRequired ? propertyBuilder : propertyBuilder.IsRequired(true);
    }

    public static PropertyBuilder<bool> MapBoolean<T>(
        this EntityTypeBuilder<T> builder,
        Expression<Func<T, bool>> exp,
        string columnName)
        where T : class
    {
        return builder.Property<bool>(exp).HasColumnName<bool>(columnName).HasColumnType<bool>("boolean")
            .IsRequired(true);
    }

    public static PropertyBuilder<bool?> MapBoolean<T>(
        this EntityTypeBuilder<T> builder,
        Expression<Func<T, bool?>> exp,
        string columnName)
        where T : class
    {
        return builder.Property<bool?>(exp).HasColumnName<bool?>(columnName).HasColumnType<bool?>("boolean");
    }

    public static PropertyBuilder<int> MapInt<T>(
        this EntityTypeBuilder<T> builder,
        Expression<Func<T, int>> exp,
        string columnName)
        where T : class
    {
        return builder.Property<int>(exp).HasColumnName<int>(columnName).HasColumnType<int>("int").IsRequired(true);
    }

    public static PropertyBuilder<int?> MapInt<T>(
        this EntityTypeBuilder<T> builder,
        Expression<Func<T, int?>> exp,
        string columnName)
        where T : class
    {
        return builder.Property<int?>(exp).HasColumnName<int?>(columnName).HasColumnType<int?>("int");
    }

    public static PropertyBuilder<DateTime> MapTimestamp<T>(
        this EntityTypeBuilder<T> builder,
        Expression<Func<T, DateTime>> exp,
        string columnName)
        where T : class
    {
        return builder.Property<DateTime>(exp).HasColumnName<DateTime>(columnName).HasColumnType<DateTime>("timestamp")
            .IsRequired(true);
    }

    public static PropertyBuilder<DateTime?> MapTimestamp<T>(
        this EntityTypeBuilder<T> builder,
        Expression<Func<T, DateTime?>> exp,
        string columnName)
        where T : class
    {
        return builder.Property<DateTime?>(exp).HasColumnName<DateTime?>(columnName)
            .HasColumnType<DateTime?>("timestamp");
    }

    public static PropertyBuilder<double> MapNumeric<T>(
        this EntityTypeBuilder<T> builder,
        Expression<Func<T, double>> exp,
        int range,
        int precision,
        string columnName)
        where T : class
    {
        PropertyBuilder<double> propertyBuilder = builder.Property<double>(exp).HasColumnName<double>(columnName);
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 2);
        interpolatedStringHandler.AppendLiteral("numeric(");
        interpolatedStringHandler.AppendFormatted<int>(range);
        interpolatedStringHandler.AppendLiteral(",");
        interpolatedStringHandler.AppendFormatted<int>(precision);
        interpolatedStringHandler.AppendLiteral(")");
        string stringAndClear = interpolatedStringHandler.ToStringAndClear();
        return propertyBuilder.HasColumnType<double>(stringAndClear).IsRequired(true);
    }

    public static PropertyBuilder<double?> MapNumeric<T>(
        this EntityTypeBuilder<T> builder,
        Expression<Func<T, double?>> exp,
        int range,
        int precision,
        string columnName)
        where T : class
    {
        PropertyBuilder<double?> propertyBuilder = builder.Property<double?>(exp).HasColumnName<double?>(columnName);
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 2);
        interpolatedStringHandler.AppendLiteral("numeric(");
        interpolatedStringHandler.AppendFormatted<int>(range);
        interpolatedStringHandler.AppendLiteral(",");
        interpolatedStringHandler.AppendFormatted<int>(precision);
        interpolatedStringHandler.AppendLiteral(")");
        string stringAndClear = interpolatedStringHandler.ToStringAndClear();
        return propertyBuilder.HasColumnType<double?>(stringAndClear);
    }

    public static PropertyBuilder<Decimal> MapNumeric<T>(
        this EntityTypeBuilder<T> builder,
        Expression<Func<T, Decimal>> exp,
        int range,
        int precision,
        string columnName)
        where T : class
    {
        PropertyBuilder<Decimal> propertyBuilder = builder.Property<Decimal>(exp).HasColumnName<Decimal>(columnName);
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 2);
        interpolatedStringHandler.AppendLiteral("numeric(");
        interpolatedStringHandler.AppendFormatted<int>(range);
        interpolatedStringHandler.AppendLiteral(",");
        interpolatedStringHandler.AppendFormatted<int>(precision);
        interpolatedStringHandler.AppendLiteral(")");
        string stringAndClear = interpolatedStringHandler.ToStringAndClear();
        return propertyBuilder.HasColumnType<Decimal>(stringAndClear).IsRequired(true);
    }

    public static PropertyBuilder<Decimal?> MapNumeric<T>(
        this EntityTypeBuilder<T> builder,
        Expression<Func<T, Decimal?>> exp,
        int range,
        int precision,
        string columnName)
        where T : class
    {
        PropertyBuilder<Decimal?> propertyBuilder = builder.Property<Decimal?>(exp).HasColumnName<Decimal?>(columnName);
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 2);
        interpolatedStringHandler.AppendLiteral("numeric(");
        interpolatedStringHandler.AppendFormatted<int>(range);
        interpolatedStringHandler.AppendLiteral(",");
        interpolatedStringHandler.AppendFormatted<int>(precision);
        interpolatedStringHandler.AppendLiteral(")");
        string stringAndClear = interpolatedStringHandler.ToStringAndClear();
        return propertyBuilder.HasColumnType<Decimal?>(stringAndClear);
    }
}