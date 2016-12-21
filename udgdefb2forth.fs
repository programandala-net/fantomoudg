#! /usr/bin/env gforth

\ udgdefb2forth.fs

\ This file is part of FantomoUDG
\ http://programandala.net

\ Last modified 201612211554

\ ==============================================================
\ Description

\ This Forth program converts Z80 assembler 'defb' directives,
\ with binary numbers representing User Defined Graphics, to hex
\ data ready to be used in a Forth program.

\ ==============================================================
\ Usage

\ ./udgdefb2forth.fs > output_file.fs

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

\ 2015-03-20: First version.
\
\ 2015-03-23: Added '90 UDG!' as default (graphic char and
\ defininig word).
\
\ 2016-12-21: Update file header and source layout.

\ ==============================================================
\ Main

2variable udg

variable scans  scans off

: ;;  ( "char" -- )  parse-name save-mem udg 2!  ;

: defb  ( "number" -- )
  parse-name evaluate s>d hex <# 32 hold # # #> type decimal
  1 scans +!  scans @ 8 =
  if  ."  90 UDG! \ " udg 2@ type scans off cr  then  ;

\ ==============================================================
\ Example data

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
