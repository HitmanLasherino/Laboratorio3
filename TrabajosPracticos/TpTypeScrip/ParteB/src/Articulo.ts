export class Articulo {
    private codigo: number;
    private denominacion: string;
    private precio: number;
    private unidadMedida: string;

    constructor(codigo: number, denominacion: string, precio: number, unidadMedida: string) {
        this.codigo = codigo;
        this.denominacion = denominacion;
        this.precio = precio;
        this.unidadMedida = unidadMedida;
    }

    public getPrecio(): number {
        return this.precio;
    }

    public getDenominacion(): string {
        return this.denominacion;
    }
}