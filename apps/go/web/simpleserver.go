package web

import (
	"fmt"
	"net/http"
)

func SimpleServer() {
	http.HandleFunc("/", func (w http.ResponseWriter, r *http.Request) {
		fmt.Fprintf(w, "Hola! Served from simple server")
	})

	fs := http.FileServer(http.Dir("static/"))
	http.Handle("/static/", http.StripPrefix("/static/", fs))
	
	port := "2000"
	fmt.Println("Simple server is listening to port: " + port +". Access it from http://localhost:" + port)
	http.ListenAndServe(":" + port, nil)
}