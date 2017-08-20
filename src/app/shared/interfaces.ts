export interface IProduct {
    unitId: string;
    companyId: string;
    came: string;
    code: string;
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
    status: number;
    unit: IUnit;
    company: ICompany;
}

export interface IUnit {
    code: string;
    description: string;
}

export interface ICompany {
    name: string;
    phone: string;
    aadharNumber: number;
    tinNumber: string;
    gstNumber: string;
}

export interface Predicate<T> {
    (item: T): boolean
}