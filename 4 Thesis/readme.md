##PDF Generierung
`pandoc -N chapters/*.md --latex-engine=pdflatex --template=template.tex --bibliography Citer.bib -o test.pdf --chapter`