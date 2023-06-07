import pygame
from pygame.locals import *

# Initialize Pygame
pygame.init()

# Set up the screen
width, height = 640, 480
screen = pygame.display.set_mode((width, height))
pygame.display.set_caption("3D Renderer")

# Define a cube's vertices
vertices = [
    (1, -1, -1),
    (1, 1, -1),
    (-1, 1, -1),
    (-1, -1, -1),
    (1, -1, 1),
    (1, 1, 1),
    (-1, -1, 1),
    (-1, 1, 1)
]

# Define a cube's edges
edges = [
    (0, 1),
    (1, 2),
    (2, 3),
    (3, 0),
    (4, 5),
    (5, 6),
    (6, 7),
    (7, 4),
    (0, 4),
    (1, 5),
    (2, 6),
    (3, 7)
]

# Define the viewing angle and projection plane distance
fov = 90
projection_distance = 3

# Main game loop
running = True
while running:
    # Clear the screen
    screen.fill((0, 0, 0))

    # Process events
    for event in pygame.event.get():
        if event.type == QUIT:
            running = False

    # Rotate and project vertices
    rotated_vertices = []
    for vertex in vertices:
        # Rotate around the y-axis
        x, y, z = vertex
        angle = pygame.time.get_ticks() / 1000  # Rotate over time
        new_x = x * pygame.math.cos(angle) + z * pygame.math.sin(angle)
        new_z = -x * pygame.math.sin(angle) + z * pygame.math.cos(angle)

        # Project onto the 2D screen
        scale = projection_distance / (projection_distance - new_z)
        screen_x = int(width / 2 + new_x * scale)
        screen_y = int(height / 2 + y * scale)
        rotated_vertices.append((screen_x, screen_y))

    # Draw edges
    for edge in edges:
        start = rotated_vertices[edge[0]]
        end = rotated_vertices[edge[1]]
        pygame.draw.line(screen, (255, 255, 255), start, end)

    # Update the screen
    pygame.display.flip()

# Quit the game
pygame.quit()
