import {Sahista} from"./sahista.js";
import { Turnir } from "./turnir.js";

export class Partija {
    constructor(beli, crni, ishod, trajanje, id, turnir) {
        this.beli = beli;
        this.crni = crni;
        this.ishod = ishod;
        this.trajanje = trajanje;
        this.id = id;
        this.turnir=turnir;
    }

    crtajPartiju(host,forma) {
        var p = document.createElement("div");
        p.className = "partija";
        var info = document.createElement("p");
        info.className = "partijaTxt";
        //tooltip
        info.innerHTML = this.beli.ime+" "+this.beli.prezime + " VS " + this.crni.ime +" "+this.crni.prezime+ " : " + this.ishod + ", trajanje partije: " + this.trajanje+"min.";
        var izmeni = document.createElement("button");
        izmeni.innerHTML = "Izmeni";
        izmeni.className = "partijaBtn unutra";
        izmeni.onclick = (ev) => {
           this.turnir.crtajFormu(forma, this,host);
        }
        var izbrisi = document.createElement("button");
        izbrisi.innerHTML = "Izbrisi";
        izbrisi.className = "partijaBtn unutra";
        izbrisi.onclick = (ev) => {
            fetch("https://localhost:5001/SahovskaFederacija/IzbrisiPartiju/"+this.id).then(data=>
            {
                if(data.ok)
                {
                    this.turnir.partije.splice(this.turnir.partije.indexOf(this),1);
                    this.turnir.osveziTurnir(host);
                }
                else
                {
                    alert("Došlo je do greške prilikom brisanja iz baze!");
                }
            })
    }
    
    p.appendChild(info);
    p.appendChild(izmeni);
    p.appendChild(izbrisi);
    host.appendChild(p);

}
}