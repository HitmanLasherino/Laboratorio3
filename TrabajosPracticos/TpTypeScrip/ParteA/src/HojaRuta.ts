import { Detalle } from "./Detalle";

export class HojaRuta {
        private fecha: Date;
        private numero: number;
        private detalles: Detalle[] = [];
    
        constructor(fecha: Date, numero: number) {
            this.fecha = fecha;
            this.numero = numero;
        }
    
        // Getter y Setter
        public getFecha(): Date {
            return this.fecha;
        }
    
        public getNumero(): number {
            return this.numero;
        }
    
        public agregarDetalle(detalle: Detalle): void {
            this.detalles.push(detalle);
        }
    
        public calcularTotalKilometros(): number {
            let totalKilometros = 0;
            for (const detalle of this.detalles) {
                totalKilometros += detalle.getKmRegreso() - detalle.getKmSalida();
            }
            return totalKilometros;
        }
}