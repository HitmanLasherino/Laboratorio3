import { DetalleFactura } from "./DetalleFactura";
import { Cliente } from "./Cliente";

export class Factura {
    private letra: string;
    private numero: number;
    private recargo: number;
    private tipoPago: string;
    private totalItems : number;
    private totalFinal: number;
    private fecha: Date;
    private cliente: Cliente;
    private detalles: DetalleFactura[];

    constructor(letra: string, numero: number, recargo: number, tipoPago: string, cliente: Cliente) {
        this.letra = letra;
        this.numero = numero;
        this.recargo = recargo;
        this.tipoPago = tipoPago;
        this.totalItems = 0;
        this.totalFinal = 0;
        this.cliente = cliente;
        this.fecha = new Date();
        this.detalles = [];
    }

    public agregarDetalle(detalle: DetalleFactura): void {
        this.detalles.push(detalle);
    }

    public calcularTotalItems(): void {
        this.totalItems = this.detalles.reduce((total, detalle) => total + detalle.getSubTotal(), 0);
    }

    public calcularTotalFinal(): void {
        this.calcularTotalItems();
        this.totalFinal = this.totalItems + this.recargo;
    }

    public getTotalFinal(): number {
        return this.totalFinal;
    }

    public getTipoPago(): string {
        return this.tipoPago;
    }
}