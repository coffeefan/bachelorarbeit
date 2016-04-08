#Headline
Bachelorarbeit

#Thesis
Generate Thesis:

`pandoc -N chapters/*.md --latex-engine=pdflatex --template=template.tex --bibliography Citer.bib -o thesis.pdf --chapter`


 rm -r build && mkdir ./build/ && cp Citer.bib ./build/ && pandoc -N chapters/*.md --latex-engine=pdflatex --template=template.tex --bibliography Citer.bib -o ./build/thesis.tex --chapter --biblatex  && pdflatex --output-directory=./build/ ./build/thesis.tex  && cd ./build && bibtex thesis.aux && cd ..  && pdflatex --output-directory=./build/ ./build/thesis.tex