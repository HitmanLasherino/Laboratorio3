import { HojaRuta } from "./HojaRuta";

export class Vehiculo {
    private patente: string;
    private marca: string;
    private modelo: string;
    private hojasRuta: HojaRuta [] = [];

    constructor(patente: string, marca: string, modelo: string) {
        this.patente = patente;
        this.marca = marca;
        this.modelo = modelo;
    }
    
    public getPatente(): string {
        return this.patente;
    }

    public getMarca(): string{
        return this.marca;
    }

    public getModelo(): string {
        return this.modelo
    }

    public agregarHojaRuta(hojaRuta: HojaRuta): void {
        this.hojasRuta.push(hojaRuta);
    }

    public calcularTotalKmRecorrido(fechaDesde: Date, fechaHasta: Date): number {
        let totalKilometros = 0;
        for (const hoja of this.hojasRuta) {
            if (hoja.getFecha() >= fechaDesde && hoja.getFecha() <= fechaHasta) {
                totalKilometros += hoja.calcularTotalKilometros();
            }
        }
        return totalKilometros;
    }
}   