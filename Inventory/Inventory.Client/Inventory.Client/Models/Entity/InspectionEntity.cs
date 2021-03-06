﻿namespace Inventory.Client.Models.Entity
{
    using Inventory.Client.Helpers;

    using Smart.ComponentModel;

    public class InspectionEntity : NotificationObject
    {
        public const int ItemCodeLength = Length.ItemCode;
        public const int ItemNameLength = Length.ItemName;
        public const int SalesPriceLength = Length.SalesPrice;
        public const int QtyLength = Length.Qty;
        public const int OriginalQtyLength = Length.Qty;
        public const int CrLfLength = Length.CrLf;

        public const int ItemCodeOffset = 0;
        public const int ItemNameOffset = ItemCodeOffset + ItemCodeLength;
        public const int SalesPriceOffset = ItemNameOffset + ItemNameLength;
        public const int QtyOffset = SalesPriceOffset + SalesPriceLength;
        public const int OriginalQtyOffset = QtyOffset + QtyLength;
        public const int CrLfOffset = OriginalQtyOffset + OriginalQtyLength;

        public const int Size = CrLfOffset + CrLfLength;

        private int detailNo;

        private string itemCode;

        private string itemName;

        private long salesPrice;

        private long qty;

        private long originalQty;

        public int DetailNo
        {
            get => detailNo;
            set => SetProperty(ref detailNo, value);
        }

        public string ItemCode
        {
            get => itemCode;
            set => SetProperty(ref itemCode, value);
        }

        public string ItemName
        {
            get => itemName;
            set => SetProperty(ref itemName, value);
        }

        public long SalesPrice
        {
            get => salesPrice;
            set => SetProperty(ref salesPrice, value);
        }

        public long Qty
        {
            get => qty;
            set => SetProperty(ref qty, value);
        }

        public long OriginalQty
        {
            get => originalQty;
            set => SetProperty(ref originalQty, value);
        }

        public void FromBytes(byte[] buffer)
        {
            itemCode = ByteSerializer.ReadString(buffer, ItemCodeOffset, ItemCodeLength);
            itemName = ByteSerializer.ReadString(buffer, ItemNameOffset, ItemNameLength);
            salesPrice = ByteSerializer.ReadLong(buffer, SalesPriceOffset, SalesPriceLength);
            qty = ByteSerializer.ReadLong(buffer, QtyOffset, QtyLength);
            originalQty = ByteSerializer.ReadLong(buffer, OriginalQtyOffset, OriginalQtyLength);
        }

        public byte[] ToBytes()
        {
            var buffer = new byte[Size];
            ByteSerializer.WriteString(itemCode, buffer, ItemCodeOffset, ItemCodeLength);
            ByteSerializer.WriteString(itemName, buffer, ItemNameOffset, ItemNameLength);
            ByteSerializer.WriteLong(salesPrice, buffer, SalesPriceOffset, SalesPriceLength);
            ByteSerializer.WriteLong(qty, buffer, QtyOffset, QtyLength);
            ByteSerializer.WriteLong(originalQty, buffer, OriginalQtyOffset, OriginalQtyLength);
            ByteSerializer.WriteCrLf(buffer, CrLfOffset);
            return buffer;
        }
    }
}
