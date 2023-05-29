#!/bin/bash
files=$(ls Models/)
#echo "$files"
for file in $(ls Models/)
do
    clearedFile=${file::-3}
    controllerName=$clearedFile"Contoller"
    $(dotnet-aspnet-codegenerator controller -name $controllerName -async -api -m $clearedFile -dc Diplom_backContext -outDir Controllers)
    #echo $contolerName
done
