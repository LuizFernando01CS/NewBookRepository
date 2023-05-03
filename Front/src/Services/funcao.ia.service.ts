import { Injectable } from '@angular/core';
import { IAService } from 'src/Services/ia.service';

@Injectable()
export class FuncaoIaService {
    apiUrl =   "";

  
    constructor(private iAService: IAService) 
    {
    }

    public EditTemplateIA()
    {
        var root = document.documentElement;
        if(localStorage.getItem("user") != undefined && localStorage.getItem("user") != null && localStorage.getItem("user") != ""){
            this.iAService.GetIAByUserId(localStorage.getItem("user") || "0").subscribe(IA => {             
                root.style.setProperty('--color-user-message', IA.userColorMessage);
                root.style.setProperty('--color-ia-message', IA.iAColorMessage);
                root.style.setProperty('--color-chatia-message', IA.iAChatColor);
            });
        }
        else{
            //default
            root.style.setProperty('--color-user-message', "lightgreen");
            root.style.setProperty('--color-ia-message', "rgb(196, 196, 196)");
            root.style.setProperty('--color-chatia-message', "rgb(247, 247, 247)");
        }

    }
}