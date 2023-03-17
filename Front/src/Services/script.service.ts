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
                $(".logo").css("left", "0px");
                $("nav").css("left", "0px");
        
                $("nav ul li .navButton em").css("transition", "2s");
                $("nav ul li .navButton em").css("opacity", "1");
        
                setTimeout(() => {
                    $("nav ul li .navButton").css("transition", "1s");
                    $("nav ul li .navButton").css("left", "70px");
                }, 170);     
            }
            else
            {
                $(".logo").css("left", "-100px");
                $("nav").css("left", "-100px");
        
                $("nav ul li .navButton em").css("transition", "1s");
                $("nav ul li .navButton em").css("opacity", "0");
        
                setTimeout(() => {
                    $("nav ul li .navButton").css("transition", "1s");
                    $("nav ul li .navButton").css("left", "130px");
                }, 170);    
            }
       }
       else if(width > 1200)
       {
            if(x < 200 && x > -10)
            {
                $('.logo')[0].style.setProperty('left', '-15px', 'important');
                $('nav')[0].style.setProperty('left', '-15px', 'important');
        
                $("nav ul li .navButton em").css("transition", "1s");
                $("nav ul li .navButton em").css("opacity", "1");
        
                setTimeout(() => {
                    $('nav ul li .navButton')[0].style.setProperty('left', '10px', 'important');
                    $('nav ul li .navButton')[1].style.setProperty('left', '10px', 'important');
                    $('nav ul li .navButton')[2].style.setProperty('left', '10px', 'important');
                    $('nav ul li .navButton')[3].style.setProperty('left', '10px', 'important');
                    $('nav ul li .navButton')[4].style.setProperty('left', '10px', 'important');
                }, 170);       
            }
            else
            {
                $('.logo')[0].style.setProperty('left', '-60px', 'important');
                $('nav')[0].style.setProperty('left', '-60px', 'important');
                
                $("nav ul li .navButton em").css("transition", "1s");
                $("nav ul li .navButton em").css("opacity", "0");
        
                setTimeout(() => {
                    $('nav ul li .navButton')[0].style.setProperty('left', '35px', 'important');
                    $('nav ul li .navButton')[1].style.setProperty('left', '35px', 'important');
                    $('nav ul li .navButton')[2].style.setProperty('left', '35px', 'important');
                    $('nav ul li .navButton')[3].style.setProperty('left', '35px', 'important');
                    $('nav ul li .navButton')[4].style.setProperty('left', '35px', 'important');
                }, 170);    
            }
       }
       else if(width > 1000)
       {
            if(x < 200 && x > -10)
            {
                $('.logo')[0].style.setProperty('left', '-5px', 'important');
                $('nav')[0].style.setProperty('left', '-5px', 'important');
        
                $("nav ul li .navButton em").css("transition", "1s");
                $("nav ul li .navButton em").css("opacity", "1");
        
                setTimeout(() => {
                    $('nav ul li .navButton')[0].style.setProperty('left', '-5px', 'important');
                    $('nav ul li .navButton')[1].style.setProperty('left', '-5px', 'important');
                    $('nav ul li .navButton')[2].style.setProperty('left', '-5px', 'important');
                    $('nav ul li .navButton')[3].style.setProperty('left', '-5px', 'important');
                    $('nav ul li .navButton')[4].style.setProperty('left', '-5px', 'important');
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
   
        if(y < 72){
            $(".navbar").css("transition", "1s");
            $(".navbar").css("top", "10px");
        }
        else{
            $(".navbar").css("transition", "1s");
            $(".navbar").css("top", "-70px");
        }
     
     }); 
    }
}
