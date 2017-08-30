export interface IProduct {
    _id: number;
    UnitId: number;
    CompanyId: number;
    Name: string;
    Code: string;
    Mrp: number;
    Price: number;
    RetailerPrice: number;
    Quantity: number;
    Stock: number;
    Cgst: number;
    Sgst: number;
    Vat: number;
    ManufacturedDate: Date;
    ExpiredDate: Date;
    Status: number;
    Unit: IUnit;
    Company: ICompany;
}

export interface IUnit {
    Code: string;
    Description: string;
}

export interface ICompany {
    Name: string;
    Phone: string;
    AadharNumber: number;
    TinNumber: string;
    GstNumber: string;
}

export interface Predicate<T> {
    (item: T): boolean
}