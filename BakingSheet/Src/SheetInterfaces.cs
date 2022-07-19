﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cathei.BakingSheet
{
    public interface ISheet : IEnumerable
    {
        string Name { get; set; }
        Type RowType { get; }

        int Count { get; }
        bool Contains(object key);
        void Add(object value);

        void PostLoad(SheetConvertingContext context);
        void VerifyAssets(SheetConvertingContext context);
    }

    public interface ISheet<TKey, out TValue> : ISheet, IReadOnlyList<TValue>
    {
        TValue this[TKey key] { get; }
        TValue Find(TKey key);

        bool Contains(TKey key);
        bool Remove(TKey key);
    }

    public interface ISheetRow
    {
        object Id { get; }
    }

    public interface ISheetRowElem
    {
        int Index { get; }
    }

    public interface ISheetRowArray
    {
        IList Arr { get; }
        Type ElemType { get; }
    }

    public interface ISheetReference
    {
        void Map(SheetConvertingContext context);

        object Id { get; set; }
        Type IdType { get; }
    }

    public interface ISheetImporter
    {
        Task<bool> Import(SheetConvertingContext context);
    }

    public interface ISheetExporter
    {
        Task<bool> Export(SheetConvertingContext context);
    }

    public interface ISheetConverter : ISheetImporter, ISheetExporter
    {

    }
}
