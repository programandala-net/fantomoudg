#! /usr/bin/env gforth

\ udg_defb_to_forth.demo.fs

\ This file is part of FantomoUDG
\ http://programandala.net/en.program.fantomoudg.html

\ Last modified 201612211827

\ ==============================================================
\ Description

\ Demo of the <udg_defb_to_forth.fs> converter.

\ This source converts UDG defined in Z80 assembly `defb`
\ directives to to Forth notation, suitable for Solo Forth.
\
\ Note the Z80 assembly comment character, ";", has been
\ duplicated.

\ ==============================================================
\ Usage

\ ./udg_defb_to_forth.demo.fs > output_file.fs

\ ==============================================================
\ Author

\ Marcos Cruz (programandala.net), 2015, 2016.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================
\ History

\ 2016-12-21: Extract from <udg_defb_to_forth.fs>.

\ ==============================================================

include udg_defb_to_forth.fs

160 udg !

;; á
defb %00001000
defb %00010000
defb %00111000
defb %00000100
defb %00111100
defb %01000100
defb %00111100
defb %00000000
;; Á
defb %00000100
defb %00001000
defb %00111100
defb %01000010
defb %01111110
defb %01000010
defb %01000010
defb %00000000
;; é
defb %00001000
defb %00010000
defb %00111000
defb %01000100
defb %01111000
defb %01000000
defb %00111100
defb %00000000
;; É
defb %00000100
defb %00001000
defb %01111110
defb %01000000
defb %01111100
defb %01000000
defb %01111110
defb %00000000
;; í
defb %00001000
defb %00010000
defb %00000000
defb %00110000
defb %00010000
defb %00010000
defb %00111000
defb %00000000
;; Í
defb %00000100
defb %00001000
defb %00111110
defb %00001000
defb %00001000
defb %00001000
defb %00111110
defb %00000000
;; ó
defb %00001000
defb %00010000
defb %00111000
defb %01000100
defb %01000100
defb %01000100
defb %00111000
defb %00000000
;; Ó
defb %00001000
defb %00010000
defb %00111100
defb %01000010
defb %01000010
defb %01000010
defb %00111100
defb %00000000
;; ú
defb %00001000
defb %00010000
defb %01000100
defb %01000100
defb %01000100
defb %01000100
defb %00111000
defb %00000000
;; Ú
defb %00000100
defb %01001010
defb %01000010
defb %01000010
defb %01000010
defb %01000010
defb %00111100
defb %00000000
;; ñ
defb %00000000
defb %01111000
defb %00000000
defb %01111000
defb %01000100
defb %01000100
defb %01000100
defb %00000000
;; Ñ
defb %00111100
defb %00000000
defb %01100010
defb %01010010
defb %01001010
defb %01000110
defb %01000010
defb %00000000
;; ü
defb %01000100
defb %00000000
defb %01000100
defb %01000100
defb %01000100
defb %01000100
defb %00111000
defb %00000000
;; Ü
defb %01000010
defb %00000000
defb %01000010
defb %01000010
defb %01000010
defb %01000010
defb %00111100
defb %00000000
;; ¿
defb %00000000
defb %00010000
defb %00000000
defb %00010000
defb %00100000
defb %01000010
defb %00111100
defb %00000000
;; ¡
defb %00000000
defb %00001000
defb %00000000
defb %00001000
defb %00001000
defb %00001000
defb %00001000
defb %00000000
;; º
defb %00011000
defb %00100100
defb %00011000
defb %00000000
defb %00111100
defb %00000000
defb %00000000
defb %00000000
;; «
defb %00000000
defb %00000000
defb %00010010
defb %00100100
defb %01001000
defb %00100100
defb %00010010
defb %00000000
;; »
defb %00000000
defb %00000000
defb %01001000
defb %00100100
defb %00010010
defb %00100100
defb %01001000
defb %00000000

bye
