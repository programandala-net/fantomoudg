#! /usr/bin/env gforth

\ udg_code_to_bin.fs

\ This file is part of FantomoUDG
\ http://programandala.net/en.program.fantomoudg.html

\ Last modified 20221106T1948+0100

\ ==============================================================
\ Description

\ This program converts ZX Spectrum raw code, containing User
\ Defined Graphics, to binary numbers printed to standard output,
\ with Forth comments.

\ ==============================================================
\ Usage

\ ./udg_code_to_bin.fs input_file.bin > output_file.txt

\ ==============================================================
\ Author

\ Marcos Cruz (programandala.net), 2022.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================
\ History

\ 2022-11-06: Start.

\ ==============================================================
\ Main

include udg_x_to_bin.fs

1 arg slurp-file udgs>bin bye

