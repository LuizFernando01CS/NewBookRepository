import { Injectable } from '@angular/core';
import * as $ from 'jquery';

@Injectable()
export class ScriptService {
    constructor() {
     }

    public ativarSideBar()
    {
       document.addEventListener("mousemove", function(event) {
        var x = event.clientX;
   
        var width = 0;
        width =  $(window).width() || 0; 
     
       if(width > 1600)
       {

            if(x < 200 && x > -10)
            {
                $(".logo").css("width", "7%");
                $("nav").css("width", "7%");
        
                $("nav ul li .navButton em").css("transition", "2s");
                $("nav ul li .navButton em").css("opacity", "1");      
            }
            else
            {
                $(".logo").css("left", "0px");

                $(".logo").css("width", "5%");
                $("nav").css("left", "0");
                $("nav").css("width", "5%");
        
                $("nav ul li .navButton em").css("transition", "1s");
                $("nav ul li .navButton em").css("opacity", "0");  
            }
       }
       else if(width > 1200)
       {
            if(x < 200 && x > -10)
            {
                $(".logo").css("width", "9%");
                $("nav").css("width", "9%");
        
                $("nav ul li .navButton em").css("transition", "2s");
                $("nav ul li .navButton em").css("opacity", "1");  
            }
            else
            {
                $(".logo").css("left", "0px");

                $(".logo").css("width", "5%");
                $("nav").css("left", "0");
                $("nav").css("width", "5%");
        
                $("nav ul li .navButton em").css("transition", "1s");
                $("nav ul li .navButton em").css("opacity", "0");  
            }
       }
       else if(width > 1000)
       {
            if(x < 200 && x > -10)
            {
                $('.logo')[0].style.setProperty('left', '-5px', 'important');
                $('nav')[0].style.setProperty('left', '0px', 'important');
        
                $("nav ul li .navButton em").css("transition", "1s");
                $("nav ul li .navButton em").css("opacity", "1");
        
                setTimeout(() => {
                    $('nav ul li .navButton')[0].style.setProperty('left', '0px', 'important');
                    $('nav ul li .navButton')[1].style.setProperty('left', '0px', 'important');
                    $('nav ul li .navButton')[2].style.setProperty('left', '0px', 'important');
                    $('nav ul li .navButton')[3].style.setProperty('left', '0px', 'important');
                    $('nav ul li .navButton')[4].style.setProperty('left', '0px', 'important');
                }, 170);              
            }
            else
            {
                $('.logo')[0].style.setProperty('left', '-30px', 'important');
                $('nav')[0].style.setProperty('left', '-30px', 'important');
                
                $("nav ul li .navButton em").css("transition", "1s");
                $("nav ul li .navButton em").css("opacity", "0");
                
                setTimeout(() => {
                    $('nav ul li .navButton')[0].style.setProperty('left', '10px', 'important');
                    $('nav ul li .navButton')[1].style.setProperty('left', '10px', 'important');
                    $('nav ul li .navButton')[2].style.setProperty('left', '10px', 'important');
                    $('nav ul li .navButton')[3].style.setProperty('left', '10px', 'important');
                    $('nav ul li .navButton')[4].style.setProperty('left', '10px', 'important');
                }, 170);    
            }
       }
     }); 
    }


    public ativarNavBar()
    {
       document.addEventListener("mousemove", function(event) {
        var x = event.clientX;
        var y = event.clientY;
   
        if(y < 120){
            $(".navbar").css("transition", "1s");
            $(".navbar").css("top", "10px");
        }
        else{
            $(".navbar").css("transition", "1s");
            $(".navbar").css("top", "-70px");
        }
     
     }); 
    }

    public AtivarComboMode()
    {
        $(".navbar").css("transition", "1s");
        $(".navbar").css("top", "10px");
    }

    public AtivarClickModal(dialogRef: any )
    {
        var divNome: any = document.querySelector(".contentModal");
        var count: any = 1

        $(document).on("click", function(e) {
        var fora = !divNome.contains(e.target);

        if(fora) 
        {
            $(divNome).slideDown("slow/400/fast");

            if(count != 1)
            dialogRef.close();
            else
            count = 2;  
            
        }
        else
            count = 2;
        });

    }
}
