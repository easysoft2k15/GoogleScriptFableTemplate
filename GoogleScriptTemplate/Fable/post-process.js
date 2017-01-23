//\Fable>babel out\bundle.js --plugins=transform-es3-property-literals,ransform-es3-member-expression-literals -o bundle-2.js


var fs=require("fs");
var filenameIn=process.argv[2];             
var filenameOut=process.argv[3];            

function patch(data)
{
    fs.writeFile(filenameOut,"this.Map=polyfill.Map;\n"+
    "this.Symbol=polyfill.Symbol;\n"+
    "this.ArrayBuffer=polyfill.ArrayBuffer;\n"+
    data);

    console.log("Patching done.");
    console.log("Copy/past content of bundle-patch.js to Google Script");
}

//Apply some bBabel Trasform
//------------------------------
function babelPostProc(data, nextFunc)
{
    var babel=require("babel-core");
    var babelOptions={
    //"presets": ["es2015"],
    "plugins": ["transform-es3-property-literals","transform-es3-member-expression-literals"]
    }

    var res=babel.transform(data,babelOptions);
    console.log("Babel processing done. Patching...");    
    return nextFunc(res.code);    
}

//Read file
//---------------
fs.readFile(filenameIn,function(err,data)
{
    if(err)
        console.log("Error: "+err);
    else   
    {
        console.log("File read. Babel processing....");
        babelPostProc(data,patch); 
    }
})


