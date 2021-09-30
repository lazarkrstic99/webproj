import {Partija} from "./partija.js";
import {Sahista} from"./sahista.js";

export class Turnir{
    constructor(naziv,zemlja,grad,id)
    {
        this.id = id;
        this.naziv = naziv;
        this.zemlja = zemlja;
        this.grad = grad;
        this.partije = [];
    }
    dodajPartiju(partija)
    {
        this.partije.push(partija);
    }
    crtajTurnir(host)
    { 
        var container = document.createElement("div");
        container.className = "turnir";
        var info = document.createElement("div");
        info.className = "tInfo";
        var p = document.createElement("h4");
        p.innerHTML="Partije: ";
        var t = document.createElement("h2");
        t.innerHTML = this.naziv + " - " + this.zemlja + ", " + this.grad;
        var f= document.createElement("div");
        f.className="partijaForm";

        info.appendChild(t);
        container.appendChild(info);
        container.appendChild(p);
        host.appendChild(container);
        //da se pribave partije
        fetch("https://localhost:5001/SahovskaFederacija/PreuzmiPartije/"+this.id).then(x=>
            {
                x.json().then(data=>
                    {
                        data.forEach(partija =>
                            {
                                console.log(partija);
                                this.partije.push(new Partija(new Sahista(partija.beliSahista.ime,partija.beliSahista.prezime,partija.beliSahista.titula,partija.beliSahista.rejting,partija.beliSahista.id),new Sahista(partija.crniSahista.ime,partija.crniSahista.prezime,partija.crniSahista.titula,partija.crniSahista.rejting,partija.crniSahista.id),partija.ishod,partija.trajanje,partija.id,this));
                            });
                            this.crtajPartije(container,f);

                            var dodaj = document.createElement("button");
                            dodaj.className="partijaBtn";
                            dodaj.innerHTML="Dodaj";
                            dodaj.onclick=(ev)=>{
                                this.crtajFormu(f,null,container);
                            }
                            container.appendChild(dodaj);
                            container.appendChild(f);
                    })
            })
        
    }
    crtajFormu(host, partija, turnirHost)
    {
        host.innerHTML="";
        var sahisti=[];//fetch od srv;
        fetch("https://localhost:5001/SahovskaFederacija/PreuzmiSahiste/").then(x=>
        {
            x.json().then(data=>
                {
                    data.forEach(sahista =>
                        {
                          sahisti.push(new Sahista(sahista.ime,sahista.prezime,sahista.rejting,sahista.titula,sahista.id));
                        });
                        var labela = document.createElement("h3");
        labela.innerHTML = "Unos partije:";
        host.appendChild(labela);

        labela = document.createElement("label");
        labela.innerHTML = "Beli:";
        host.appendChild(labela);
        let selBeli = document.createElement("select");
        sahisti.forEach(x=>{
            var opt= document.createElement("option");
            opt.value=x.id;
            opt.innerHTML=x.ime+" "+x.prezime+": "+x.rejting;
            selBeli.appendChild(opt);
        });
        host.appendChild(selBeli);

        
        labela = document.createElement("label");
        labela.innerHTML = "Crni:";
        host.appendChild(labela);
        let selCrni = document.createElement("select");
        sahisti.forEach(x=>{
            var opt= document.createElement("option");
            opt.value=x.id;
            opt.innerHTML=x.ime+" "+x.prezime+": "+x.rejting;
            selCrni.appendChild(opt);
        });
        host.appendChild(selCrni);

        labela = document.createElement("label");
        labela.innerHTML = "Trajanje:";
        host.appendChild(labela);

        var tr=document.createElement("input");
        tr.type="number";
        host.appendChild(tr);


        labela = document.createElement("label");
        labela.innerHTML = "Ishod:";
        host.appendChild(labela);

        /*var is=document.createElement("input");
        host.appendChild(is);*/
        var ishodi = ["Beli pobedio","Crni pobedio","Remi"];
        let selIshod = document.createElement("select");
        ishodi.forEach(x=>{
            var option = document.createElement("option");
            option.className = x;
            option.innerHTML = x;
            selIshod.appendChild(option);
        });
        host.appendChild(selIshod);
        if(partija!=null)
        {
            for( var i=0;i<selBeli.options.length;i++)
            {
                if(selBeli.options[i].value==partija.beli.id)
                    selBeli.selectedIndex=i;
            }
            for(i=0;i<selCrni.options.length;i++)
            {
                if(selCrni.options[i].value==partija.crni.id)
                    selCrni.selectedIndex=i;
            }
            tr.value=partija.trajanje;
            selIshod.value=partija.ishod;
        }

        var btn=document.createElement("button");
        btn.className="partijaBtn";
        btn.innerHTML="Potvrdi";
        btn.onclick=(ev)=>{
            if(selCrni.value != selBeli.value)
            {
            if(partija==null)
            {
                //validacija
                fetch("https://localhost:5001/SahovskaFederacija/UpisiPartiju/"+selBeli.value+"/"+selCrni.value+"/"+this.id,{
                method:"POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(
                    {
                       ishod: selIshod.value,
                       trajanje: tr.value
                    }
                )
            }).then(data=>
                {
                    if(data.ok)
                    { 
                        host.innerHTML="";
                        this.osveziTurnir(turnirHost);
                    }
                    else
                    {
                        alert("Došlo je do greške prilikom upisa!");
                    }
                })
               
            }
            else
            {
                //validacija
                fetch("https://localhost:5001/SahovskaFederacija/IzmeniPartiju/"+partija.id+"/"+selBeli.value+"/"+selCrni.value+"/"+this.id,{
                method:"PUT",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(
                    {
                       ishod: selIshod.value,
                       trajanje: tr.value
                    }
                )
            }).then(data=>
                {
                    if(data.ok)
                    { 
                        host.innerHTML="";
                        this.osveziTurnir(turnirHost);
                    }
                    else
                    {
                        alert("Došlo je do greške prilikom upisa!");
                    }
                })
            }
           
        }
        else
        { 
            alert("Ne mozete izabrati dva ista igraca!");
            
        }
    }
    host.appendChild(btn);
                })
        })
        

        
    }
    crtajPartije(host,forma)
    {
        this.partije.forEach(x => {
            x.crtajPartiju(host,forma);
            })
    }
    osveziTurnir(container)
    {
        container.innerHTML="";
        var info = document.createElement("div");
        info.className = "tInfo";
        var p = document.createElement("h4");
        p.innerHTML="Partije: ";
        var t = document.createElement("h2");
        t.innerHTML = this.naziv + " - " + this.zemlja + ", " + this.grad;
        var f= document.createElement("div");
        f.className="partijaForm";

        info.appendChild(t);
        container.appendChild(info);
        container.appendChild(p);
        //da se pribave partije
        fetch("https://localhost:5001/SahovskaFederacija/PreuzmiPartije/"+this.id).then(x=>
            {
                x.json().then(data=>
                    {
                        this.partije=[];
                        data.forEach(partija =>
                            {
                                console.log(partija);
                                this.partije.push(new Partija(new Sahista(partija.beliSahista.ime,partija.beliSahista.prezime,partija.beliSahista.titula,partija.beliSahista.rejting,partija.beliSahista.id),new Sahista(partija.crniSahista.ime,partija.crniSahista.prezime,partija.crniSahista.titula,partija.crniSahista.rejting,partija.crniSahista.id),partija.ishod,partija.trajanje,partija.id,this));
                            });
                            this.crtajPartije(container,f);

                            var dodaj = document.createElement("button");
                            dodaj.className="partijaBtn";
                            dodaj.innerHTML="Dodaj";
                            dodaj.onclick=(ev)=>{
                                this.crtajFormu(f,null,container);
                            }
                            container.appendChild(dodaj);
                            container.appendChild(f);
                    })
            })
    }
}