import { Turnir } from "./turnir.js";
import {Partija} from "./partija.js";
import {Sahista} from"./sahista.js";

window.onload = init()
function init()
{
    document.body.innerHTML="";
    var turniri = [];
    var g = document.createElement("div");
    g.className = "glavno";
    document.body.appendChild(g);
    var naslov=document.createElement("h1");
    naslov.innerHTML="Sahovska federacija";
    g.appendChild(naslov);
    //da se preuzmu turniri
    fetch("https://localhost:5001/SahovskaFederacija/PreuzmiTurnire/").then(x=>
    {
        x.json().then(data=>
            {
                data.forEach(turnir => {
                    turniri.push(new Turnir(turnir.naziv,turnir.zemlja,turnir.grad,turnir.id));
                    turniri[turniri.length-1].crtajTurnir(g);
                });
                var f = document.createElement("div");
                f.className="turnirForma";

                var dodaj=document.createElement("button")
                dodaj.className="turnirBtn";
                dodaj.innerHTML="Dodaj turnir";
                dodaj.onclick=(ev)=>{
                f.innerHTML="";

                var labela = document.createElement("label");
                labela.innerHTML = "Naziv turnira:";
                f.appendChild(labela);

                var naziv=document.createElement("input");
                f.appendChild(naziv);

                labela = document.createElement("label");
                labela.innerHTML = "Zemlja:";
                f.appendChild(labela);
                var grad=document.createElement("input");
                f.appendChild(grad);

                labela = document.createElement("label");
                labela.innerHTML = "Grad:";
                f.appendChild(labela);
                var mesto=document.createElement("input");
                f.appendChild(mesto);

                var btn=document.createElement("button");
                btn.className="turnirBtn";
                btn.innerHTML="Potvrdi";
                btn.onclick=(ev)=>
                {
                    //validacija
                    //post na server
                    fetch("https://localhost:5001/SahovskaFederacija/UpisiTurnir/",{
                        method:"POST",
                        headers: {
                            "Content-Type": "application/json"
                        },
                        body: JSON.stringify(
                            {
                                naziv:naziv.value,
                                zemlja:grad.value,
                                grad:mesto.value
                            }
                        )
                    }).then(data=>
                        {
                            if(data.ok)
                            {
                               init();
                            }
                            else
                            {
                                alert("Došlo je do greške prilikom upisa!");
                            }
                        })
                }
                f.appendChild(btn);
            }
            g.appendChild(dodaj);
            g.appendChild(f);
            
            })
    });
}
