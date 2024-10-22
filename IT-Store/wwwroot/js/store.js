document.getElementById("anchor").addEventListener("click",(ev)=>{
    ev.preventDefault();

    let categoryIds="";
    let i=0;
    for (const item of document.querySelectorAll(".categoryIds")) {
        if(item.checked){
            categoryIds=categoryIds +(i==0?"":",")+item.value;
            i++;
        }
    }

    let brandids="";
    i=0;
    for (const item of document.querySelectorAll(".brandids")) {
        if(item.checked){
            brandids=brandids +(i==0?"":",")+item.value
            i++
        }
    }

    let minPrice=Number.parseInt( document.getElementById("price-min").value);
    let maxPrice=Number.parseInt(document.getElementById("price-max").value);
    let searchterm=ev.target.getAttribute("searchterm");

    var submit=document.querySelector("#submit");
    submit.href=`/storefilters?brandIds=${brandids}&categoryIds=${categoryIds}&maxPrice=${maxPrice}&minPrice=${minPrice}&searchTerm=${searchterm}`;
    console.log(submit.href);
    submit.click();
})
