#Headline
Bachelorarbeit

#Thesis
Generate Thesis:

`pandoc -N chapters/*.md --latex-engine=pdflatex --template=template.tex --bibliography Citer.bib -o thesis.pdf --chapter`
